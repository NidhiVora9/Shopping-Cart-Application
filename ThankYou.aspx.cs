using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ThankYou : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string ordernum = SessionFacade.CUSTOMERORDERNUM;
            Cart ct = (Cart)Session["MyCart"];
            string msgbody = "<h3> Thank you for your order with XYZ Shop </h3>";
            msgbody += "<b>Your Order Number=" + ordernum + " with XYZ Shop</b><br>";
            msgbody += "<table border=1>";
            msgbody += "<tr> <th> Item Number <th> Product Description <th> Quantity <th> Price/Item <th> Total</tr>";
            double rowtotal = 0.0;
            double finalTotal = 0.0;

            foreach(CartItem item in ct.list)
            {
                rowtotal = (double.Parse(item.Price) * double.Parse(item.Qty))+double.Parse(item.ShippingCost);
                finalTotal += rowtotal;
                msgbody += "<tr> <td> " + item.PID +
                      " <td> " + item.PName +
                      " <td> " + item.Qty + " <td> $" +
                      item.Price + "<td> $" + rowtotal.ToString();

            }
            msgbody += " <tr><td><td><td><td><b>Total cost</b> = <td>$" + finalTotal.ToString() + "</tr>";
            msgbody += " </table><br>Please allow 2-3 days for delivery of above items <br>";
            msgbody += " <br><b>Thank you </b> for shopping with XYZ Shop ";
            msgbody += " <br>A confirmation email has been sent to you with the above information";
            lblSummary.Text = msgbody;
            Session["MyCart"] = null;
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }
}