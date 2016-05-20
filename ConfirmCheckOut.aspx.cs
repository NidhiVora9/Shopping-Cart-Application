using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ConfirmCheckOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string uid = "";
            if(SessionFacade.CUSTOMERID!=null)
            {
                uid=(string)SessionFacade.CUSTOMERID;
                try
                {
                    IBusinessFunctions ibaf = GenericFactory<BusinessLayer, IBusinessFunctions>.CreateInstance();
                    DataTable dt = ibaf.GetCustomerInfo(uid);
                    lblfirstname.Text = dt.Rows[0]["FirstName"].ToString();
                    lbllastname.Text = dt.Rows[0]["LastName"].ToString();
                    txtStreet.Text = dt.Rows[0]["Address"].ToString();
                    txtCity.Text = dt.Rows[0]["City"].ToString(); ;
                    txtState.Text = dt.Rows[0]["State"].ToString();
                    txtZipcode.Text = dt.Rows[0]["Zipcode"].ToString();
                    txtCCNumber.Text = dt.Rows[0]["CCNumber"].ToString();
                    txtExpiration.Text = dt.Rows[0]["CCExpiration"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                }
                catch(Exception ex)
                {
                    lblStatus.Text = ex.Message;        
                }
            }
        }
    }
    protected void btnUpdateInfo_Click(object sender, EventArgs e)
    {

        string uid = "";
        if(Page.IsValid)
        {
            try
            {
                if(SessionFacade.CUSTOMERID!=null)
                {
                    uid = (string)SessionFacade.CUSTOMERID;
                    string street = txtStreet.Text.Trim();
                    string city = txtCity.Text;
                    string state = txtState.Text;
                    string zipcode = txtZipcode.Text;
                    string ccnum = txtCCNumber.Text;
                    string cctype = ddlCCType.SelectedItem.ToString();
                    string expdate = txtExpiration.Text;
                    string email = txtEmail.Text;
                    IBusinessFunctions ibaf = GenericFactory<BusinessLayer, IBusinessFunctions>.CreateInstance();
                    int res = ibaf.UpdateCustomerInfo(uid, street, city, state, zipcode, ccnum, cctype, expdate, email);
                    if(res!=null)
                    {
                        lblStatus.Text = "Updated successfully";
                    }
                }
            }
            catch(Exception ex)
            {
                lblStatus.Text = ex.Message;

            }
        }
    }
    protected void btnConfirmCheckOut_Click(object sender, EventArgs e)
    {
        Cart ct = (Cart)Session["MyCart"];
        SqlTransaction sqtr = null;
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ShoppingApplication"].ConnectionString;
        con.Open();
        sqtr = con.BeginTransaction();
        int orderNum = 0;
        bool bOrderPlaceSuccess = false;
        double totalPrice = 0;
        int nQty = 0;
        try
        {
            string sql = "SELECT MAX(OrderNo) AS MAXORDNO FROM Orders";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Transaction = sqtr;
            object obj = cmd.ExecuteScalar();
            if(obj==null)
            {
                orderNum = 1;
            }
            else
            {
                if (obj.ToString() != "")
                    orderNum = int.Parse(obj.ToString()) + 1;
                else
                    orderNum = 1;
            }
            string sql1 = "INSERT INTO Orders (OrderNo,UserID, OrderDate) VALUES ("
                + orderNum.ToString() + ",'" + (string)SessionFacade.CUSTOMERID + "','" +
                System.DateTime.Now.ToString() + "')";
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            cmd1.Transaction = sqtr;
            int rows = cmd1.ExecuteNonQuery();
            string sql2 = "";
            SqlCommand cmd2;
            foreach(CartItem item in ct.list)
            {
                sql2 = "INSERT INTO OrderDetails (OrderNo,ItemNo, ItemDesc, Qty, Price) VALUES ("
                        + orderNum.ToString() + "," + item.PID +
                        ",'" + item.PName.Replace("'", "''") + "'," +
                        item.Qty + "," + item.Price + ")";
                cmd2 = new SqlCommand(sql2, con);
                cmd2.Transaction = sqtr;
                rows = cmd2.ExecuteNonQuery();
                totalPrice = totalPrice + double.Parse(item.Price) * (double.Parse(item.Qty));
                nQty = nQty + int.Parse(item.Qty);
            }
            sqtr.Commit();
            con.Close();
            SessionFacade.CUSTOMERORDERNUM = orderNum.ToString();
            bOrderPlaceSuccess = true;
        }
        catch(Exception ex)
        {
            sqtr.Rollback();
            lblStatus.Text = ex.Message;
        }
        finally
        {
            con.Close();
        }
        if (bOrderPlaceSuccess == true)
        {
            try
            {
                DataAccess da=new DataAccess();
                string sql4 = "Select Email from CustomerInfos where UserID="
                    + (string)SessionFacade.CUSTOMERID;
                object obj = da.GetScalar(sql4);
                string email = obj.ToString();
                MailMessage msg = new MailMessage();
                msg.To.Add(email);
                msg.From = new System.Net.Mail.MailAddress("nidhi.vora018@gmail.com");
                msg.Headers.Add("Reply-To", "nidhi.vora018@gmail.com");
                msg.Subject = "Your Order Number=" + orderNum.ToString() +
                   " with XYZ Shop";
                string msgbody = "<h3>Your Order Number=" + orderNum.ToString() + " with XYZ Shop</h3>";
                msgbody += "<table border=1>";
                msgbody += "<tr> <th> Item Number <th> Product Description <th> Quantity <th> Price/Item <th> Total</tr>";
                double rowtotal = 0.0;
                foreach (CartItem item in ct.list)
                {
                    rowtotal = double.Parse(item.Price) * double.Parse(item.Qty);
                    msgbody += "<tr> <td> " + item.PID +
                    " <td> " + item.PName +
                    " <td> " + item.Qty + " <td> $" +
                        item.Price + "<td> $" + rowtotal.ToString();
                }
                msgbody += " <tr><td><td><td><td><b>Total cost</b> = <td>$" + totalPrice.ToString() + "</tr>";
                msgbody += " </table><br>Please allow 2-3 days for delivery of above items <br>";
                msgbody += " <br><b>Thank you </b> for shopping with XYZ Shop ";
              //  msg.Body = msgbody;
                SmtpClient smtp = new SmtpClient("gmail.com");
                msg.Priority = System.Net.Mail.MailPriority.High;
                smtp.Send(msg);
                lblStatus.Text = "Your email has been sent";
                Response.Redirect("ThankYou.aspx");
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Order was placed successfully.<br> " +
                    "However we could not send email to the " +
                "address you had provided. <br>" +
                    ex.Message;
                Response.Redirect("ThankYou.aspx");
            }
        }
    }
}