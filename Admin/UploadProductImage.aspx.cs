using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_UploadProductImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnUploadPImage_Click(object sender, EventArgs e)
    {
        string dir = Server.MapPath("../PImages");
        FileInfo fi = new FileInfo(txtFname.Text);
        string fname = Path.Combine(dir, fi.Name);
        if (null != fUpload.PostedFile)
        {
            try
            {
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