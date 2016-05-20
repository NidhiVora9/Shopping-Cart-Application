using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_RegisterRoles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegisterRoles_Click(object sender, EventArgs e)
    {
        try
        {
            string roleName = txtRoleName.Text;
            string roleDesc = txtRoleDesc.Text;
            IBusinessFunctions ibf = GenericFactory<BusinessLayer, IBusinessFunctions>.CreateInstance();
            int rows = ibf.RegisterNewRole(roleName, roleDesc);
            if(rows>0)
            {
                lblStatus.Text = "Role added successfully";
            }
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }
}