using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_RegisterRoles : System.Web.UI.Page
{
    DataTable dt;
    DataTable dt1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            IBusinessFunctions ibf = GenericFactory<BusinessLayer, IBusinessFunctions>.CreateInstance();
            dt = ibf.DisplayUsers();
            dt1 = ibf.DisplayRoles();
            for (int i = 0; i < dt.Rows.Count;i++)
            {
                ddlUserNames.Items.Add(dt.Rows[i]["Username"].ToString());
                ddlUserNames.Items[i].Value = dt.Rows[i]["UserID"].ToString();
            }
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                ddlRoles.Items.Add(dt1.Rows[i]["Role"].ToString());
                ddlRoles.Items[i].Value = dt1.Rows[i]["RoleID"].ToString();
            }
        }
    }
   
    protected void btnAssignRole_Click(object sender, EventArgs e)
    {

        try
        {
            string userId = ddlUserNames.SelectedItem.Value;
            string roleId = ddlRoles.SelectedItem.Value;
            IBusinessFunctions ibf = GenericFactory<BusinessLayer, IBusinessFunctions>.CreateInstance();
            int rows = ibf.RegisterRoles(userId, roleId);
            if (rows > 0)
            {
                lblStatus.Text = "Role assigned successfully";
            }
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }
}