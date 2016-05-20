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
    string category;
    string pImage;
    protected void Page_Load(object sender, EventArgs e)
    {
      
                
                IBusinessFunctions ibf = GenericFactory<BusinessLayer, IBusinessFunctions>.CreateInstance();
                dt = ibf.getProductCategories();  
                if(SessionFacade.ROLE!=null)
                {
                    if(SessionFacade.ROLE=="ElectronicsManager")
                    {
                        lblCategory.Text = dt.Rows[0]["CatDesc"].ToString();
                        category = dt.Rows[0]["CatID"].ToString();  
                    }

                    else if (SessionFacade.ROLE == "LuggageManager")
                    {
                        lblCategory.Text = dt.Rows[2]["CatDesc"].ToString();
                        category = dt.Rows[2]["CatID"].ToString();
                    }
                    else if (SessionFacade.ROLE == "BeautyManager")
                    {
                        lblCategory.Text = dt.Rows[4]["CatDesc"].ToString();
                        category = dt.Rows[4]["CatID"].ToString();
                    }
                    else if (SessionFacade.ROLE == "SportsManager")
                    {
                        lblCategory.Text = dt.Rows[3]["CatDesc"].ToString();
                        category = dt.Rows[3]["CatID"].ToString();
                    }
                    else if (SessionFacade.ROLE == "KitchenManager")
                    {
                        lblCategory.Text = dt.Rows[1]["CatDesc"].ToString();
                        category = dt.Rows[1]["CatID"].ToString();
                    }                        
        }
          
    }


    protected void btnAddProduct_Click(object sender, EventArgs e)
    {
        try
        {
            string catId = category;
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
        pImage = Path.GetFileName(fUpload.FileName);
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

  
