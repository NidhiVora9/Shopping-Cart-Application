using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["MyCart"]==null)
        {
            lblStatus.Text = "Your shopping cart is empty. Please add some items to check out.";
            ShoppingCart.Visible = false;
        }
    }
    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        Response.Redirect("CheckOut.aspx");
    }
    protected void btnContinueShopping_Click(object sender, EventArgs e)
    {
        if(SessionFacade.CATID!=null)
        {
            string catID = (string)SessionFacade.CATID;
            Response.Redirect("DisplayProducts.aspx?catID=" + catID);
        }
        else
        {
            Response.Redirect("DisplayProducts.aspx?catID=10");
        }
    }
}