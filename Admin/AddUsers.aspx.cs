using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }
    protected void btnAddUsers_Click(object sender, EventArgs e)
    {
        try
        {
            string username = txtusername.Text;
            string pwd = txtpassword.Text;
            string pHint = txtpaswordques.Text;
            string pAns = txtpasswordans.Text;
            IBusinessFunctions ibf = GenericFactory<BusinessLayer, IBusinessFunctions>.CreateInstance();
            bool check = ibf.checkUsername(username);
            if (check)
            {
                int rows = ibf.RegisterUsers(username, pwd, pHint, pAns);
                if (rows > 0)
                {
                    lblStatus.Text = "User added successfully";
                }
            }
            else
            {
                lblStatus.Text = "Username already exists";
            }
        }
        catch(Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }
}