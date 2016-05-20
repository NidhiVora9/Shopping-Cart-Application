using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CheckOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["MyCart"]==null)
        {
            lblStatus.Text = "Your shopping cart is empty" +
                "Please add product(s) to it before you can checkout";
        }
        else
        {
            Cart ct = (Cart)Session["MyCart"];
            if (ct.list.Count == 0)
            {
                lblStatus.Text = "Your Shopping Cart is empty" +
                    "Please add product(s) to it before you can checkout";
               
            }
            else
            {
                // check if someone already logged in
                if (SessionFacade.CUSTOMERID != null)
                    Response.Redirect("ConfirmCheckOut.aspx");
            }
        }
    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        IBusinessAuthentication ibau = GenericFactory<BusinessLayer, IBusinessAuthentication>.CreateInstance();

        try
        {
            string username = ibau.isValidUser(Utils.StripPunctuation(txtusername.Text), Utils.StripPunctuation(txtpassword.Text));
            
            if (username!=null)
            {
                SessionFacade.CUSTOMERID = username;
                lblStatus.Text = "Welcome " + txtusername.Text;
                Response.Redirect("ConfirmCheckOut.aspx");
            }
            else
            {
                lblStatus.Text = "Invalid User";
            }
        }
        catch(Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }
}