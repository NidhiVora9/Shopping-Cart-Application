using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShoppingCart : System.Web.UI.UserControl
{
    Cart mycart = new Cart();
    DataTable dt = new DataTable();
    static TextBox dl;
    protected void Page_Load(object sender, EventArgs e)
    {
            
        if(Session["MyCart"]==null)
        {
            Session["MyCart"] = mycart;
        }
        else
        {
            mycart = (Cart)Session["MyCart"];
        }
        if (!IsPostBack)
        {
            IBusinessFunctions ibf = GenericFactory<BusinessLayer, IBusinessFunctions>.CreateInstance();
            dt = ibf.ShowShoppingCart(mycart);
            refresh(dt);
        }
    }
    void addControl()
    {
        int i = 0;
        foreach (GridViewRow row in gv1.Rows)
        {

            if (row.RowType == DataControlRowType.DataRow)
            {
                dl = (TextBox)row.FindControl("txtqty");
                string qty = dt.Rows[i]["qty"].ToString();
                dl.Text = qty;
            }
            i++;
        }
       
    }
   void refresh(DataTable dt)
    {
        gv1.DataSource = dt;    
        gv1.DataBind();
        addControl();
        gv1.Rows[gv1.Rows.Count - 1].Visible = false;
        total_amount.Text = dt.Rows[dt.Rows.Count - 1]["PriceTotal"].ToString();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Session["MYCARTOLD"] = mycart;
        Session["MyCart"] = null;
        string reqPage = Request["SCRIPT_NAME"];
        Response.Redirect(reqPage);
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Session["MYCARTOLD"] = mycart.Clone();
        mycart.list.Clear();
        Cart newcart = new Cart();
        int i = 0;

        foreach (GridViewRow row in gv1.Rows)
        {
            if (i < gv1.Rows.Count - 1)
            {
                CartItem item = new CartItem();
                if (row.RowType == DataControlRowType.DataRow)
                {
                    dl = (TextBox)row.FindControl("txtqty");
                    item.PID = gv1.Rows[i].Cells[0].Text;
                    item.PName = gv1.Rows[i].Cells[1].Text;
                    item.Price = gv1.Rows[i].Cells[2].Text;
                    item.ShippingCost = gv1.Rows[i].Cells[4].Text;
                    item.Qty = dl.Text;
                    newcart.list.Add(item);
                }
                i++;
            }
        }
        
        Session["MyCart"] = newcart;
        IBusinessFunctions ibf = GenericFactory<BusinessLayer, IBusinessFunctions>.CreateInstance();
        dt = ibf.ShowShoppingCart(newcart);
        refresh(dt);
        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Session["MYCARTOLD"] != null)
        {
            mycart = (Cart)Session["MYCARTOLD"];
            Session["MyCart"] = mycart;
            string reqPage = Request["SCRIPT_NAME"];
            Response.Redirect(reqPage);
        }
    }

    
    protected void removeItem_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gv1.Rows[index];
            mycart =(Cart)Session["MyCart"];
            mycart.list.RemoveAt(index);
            IBusinessFunctions ibf = GenericFactory<BusinessLayer, IBusinessFunctions>.CreateInstance();
            dt = ibf.ShowShoppingCart(mycart);
            refresh(dt);
        }
    }
}