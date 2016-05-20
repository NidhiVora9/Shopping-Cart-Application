using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductDetails : System.Web.UI.Page
{
   Cart myCart = new Cart();
   public DataTable dt = null;
   string qtyvalue="1";
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if(Session["MyCart"]==null)
            {
                Session["MyCart"] = myCart;
            }
            else
            {
                myCart = (Cart)Session["MyCart"];
            }
             string PID = Request["PID"];
             IBusinessFunctions ibf = GenericFactory<BusinessLayer, IBusinessFunctions>.CreateInstance();
             dt= ibf.GetProductDetails(PID);
             lblProdDesc.Text = dt.Rows[0]["ProductSDesc"].ToString();
             string price = dt.Rows[0]["Price"].ToString();
             SessionFacade.PRODUCTID = dt.Rows[0]["ProductId"].ToString();
             SessionFacade.PRODNAME = dt.Rows[0]["ProductSDesc"].ToString();
             lblPrice.Text = "$" + price.Substring(0,5);
             SessionFacade.PRICE = price.Substring(0, 5);
             string shippingcost = dt.Rows[0]["ShippingCost"].ToString();
             shippingcost = shippingcost.Substring(0, 4);
             SessionFacade.SHIPPING = shippingcost;
              if(shippingcost=="0.00")
              {
                  lblShipping.Text = "Free Shipping";

              }
              else
              {
                  lblShipping.Text = shippingcost;
              }
             if (!IsPostBack)
             {
                 ddl.DataSource = Enumerable.Range(1, 15);
                 ddl.DataBind();
             }
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }

    }
    public double GetRandomNumber(double minimum, double maximum)
    {
        Random random = new Random();
        return random.NextDouble() * (maximum - minimum) + minimum;
    }
    protected void ddl_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        qtyvalue = (string)ddl.SelectedValue;
    }
    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        string pid = (string)SessionFacade.PRODUCTID;
        string pname = (string)SessionFacade.PRODNAME; //short description
        string price = (string)SessionFacade.PRICE;
        string shippingcost = (string)SessionFacade.SHIPPING;
        CartItem og_item = new CartItem();
        CartItem copy_item=new CartItem();
        og_item.PID = pid;
        og_item.Price = price;
        og_item.PName = pname;
        og_item.Qty = qtyvalue.ToString();
        og_item.ShippingCost = shippingcost.ToString();
        int totalItems =myCart.list.Count;
        for(int num_item=0;num_item<totalItems;num_item++)
        {
            copy_item = (CartItem)myCart.list[num_item];
            if(copy_item.PID==pid)
            {
                int qty = Int32.Parse(og_item.Qty);
                copy_item.Qty = qty.ToString();
                myCart.list.RemoveAt(num_item);
                og_item = copy_item;
                break;
            }
        }
        myCart.list.Add(og_item);
        lblAddToCart.Text = og_item.Qty + " items of " + og_item.PName + "added to your cart";
    }
    protected void btnViewCart_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewCart.aspx");
    }
}