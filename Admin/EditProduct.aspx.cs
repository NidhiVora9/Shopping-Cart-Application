using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EditProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string pid = "";
            string dd = Request["PID"];
            if (dd == null)
            {
                pid ="-1";
            }
            else
            {
                pid = Request["PID"];
            }
            try
            {
                IBusinessFunctions ibf = GenericFactory<BusinessLayer, IBusinessFunctions>.CreateInstance();
                DataTable dt = ibf.GetProductDetails(pid);
                int rows = dt.Rows.Count;
                if (rows == 0)
                {
                    lblStatus.Text = "No Product ID was specified, please " +
                        "go to View Products Page and select a product first";
                }
                else
                {
                    string catID = dt.Rows[0]["CatID"].ToString();
                    string catDesc = ibf.getCategoryDesc(catID);
                    lblCategory.Text = catDesc;
                    lblProductID.Text = dt.Rows[0]["ProductID"].ToString();
                    txtShortDesc.Text = dt.Rows[0]["ProductSDesc"].ToString();
                    txtLongDesc.Text = dt.Rows[0]["ProductLDesc"].ToString();
                    txtPrice.Text = dt.Rows[0]["Price"].ToString();
                    lblProdImage.Text = dt.Rows[0]["ProductImage"].ToString();
                    bool inStock = (bool)dt.Rows[0]["InStock"];
                    if(inStock==true)
                    {
                        chkInStock.Checked = true;

                    }
                    else
                    {
                        chkInStock.Checked = false;
                    }
                    txtInventory.Text = dt.Rows[0]["Inventory"].ToString();
                    imgProduct.ImageUrl = "../PImages/" + lblProdImage.Text;
                }

            }   
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string pid = lblProductID.Text;
            string shortDesc = txtShortDesc.Text;
            string LongDesc = txtLongDesc.Text.Replace("'", "''");
            string price = txtPrice.Text;
            string inStock = "0";
            bool InStock = chkInStock.Checked;
            if(InStock==true)
            {
                inStock = "1";
            }
            string pImage = lblProdImage.Text;
            string Inventory = txtInventory.Text;

            IBusinessFunctions ibf = GenericFactory<BusinessLayer, IBusinessFunctions>.CreateInstance();
            int rows = ibf.UpdateProducts(shortDesc, LongDesc, pImage, price, inStock, Inventory, pid);
            if(rows>0)
            {
                lblStatus.Text = "Product specs updated successfully";
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
        string filename = Path.GetFileName(fUpload.FileName);
        FileInfo fi = new FileInfo(filename);
        lblProdImage.Text = filename;
        string fname = Path.Combine(dir, fi.Name);
        if (null != fUpload.PostedFile)
        {
            try
            {
                fUpload.PostedFile.SaveAs(fname);
                lblStatus.Text = "File uplodaded successfully";
                imgProduct.ImageUrl = "../PImages/" + lblProdImage.Text;
                
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
