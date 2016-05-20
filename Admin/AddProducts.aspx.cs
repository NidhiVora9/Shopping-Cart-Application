using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddProducts : System.Web.UI.Page
{
    DataTable dt;
    string pImage;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
                IBusinessFunctions ibf = GenericFactory<BusinessLayer, IBusinessFunctions>.CreateInstance();
                dt = ibf.getProductCategories();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ddlCategory.Items.Add(dt.Rows[i]["CatDesc"].ToString());
                    ddlCategory.Items[i].Value = dt.Rows[i]["CatID"].ToString();
                }
        }
          
    }

    protected void btnAddProduct_Click(object sender, EventArgs e)
    {
        try
        {
            string catId = ddlCategory.SelectedItem.Value;
            string ProdName = txtShortDesc.Text;
            string Longdesc = txtLongDesc.Text;
            pImage = lblProdImage.Text;
            string price = txtPrice.Text;
            string Inventory = txtInventory.Text;
            string ShippingCost = txtShipping.Text;
            string inStock="0";
            if (chkInStock.Checked == true)
                inStock = "1";
            IBusinessFunctions ibf = GenericFactory<BusinessLayer, IBusinessFunctions>.CreateInstance();
            int rows = ibf.InsertProducts(catId, ProdName, Longdesc, pImage, price, inStock, Inventory, ShippingCost);
            if(rows>0)
            {
                lblStatus.Text = "Product Added successfully";

            }
        }
        catch (Exception ex)
        {
           lblStatus.Text = ex.Message;
        }
    }
    protected void btnUploadPImage_Click(object sender, EventArgs e)
    {
        string dir = Server.MapPath("../PImages");
        pImage=Path.GetFileName(fUpload.FileName);
        FileInfo fi = new FileInfo(pImage);
        string fname = Path.Combine(dir, fi.Name);
        
        if (null != fUpload.PostedFile)
        {
            try
            {
                lblProdImage.Text = pImage;
                fUpload.PostedFile.SaveAs(fname);
                lblStatus.Text = "File uplodaded successfully";
            }

            catch (Exception ex)
            {
                lblStatus.Text = "error" + ex.Message;
            }
        }
        else
        {
            lblStatus.Text = "no file specified:" + fname;
        }
    }
   
}


  
