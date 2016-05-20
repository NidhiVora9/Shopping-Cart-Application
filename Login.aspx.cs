using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (SessionFacade.USERNAME != null)
            {
                lblStatus.Text = "Already Logged in.Please Logout to login as a different user";
            }
        }
        
    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        string username = txtusername.Text;
        string password = txtpassword.Text;
        IBusinessAuthentication ibau = GenericFactory<BusinessLayer, IBusinessAuthentication>.CreateInstance();
        string acceslevel = ibau.isValidUser(username, password);
        if(acceslevel!="")
        {
            string roles = ibau.GetRolesForUser(username);
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddMinutes(30), false, roles);
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie authCookie = new HttpCookie
                (FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(authCookie);
           
            //FormsAuthentication.RedirectFromLoginPage(username.ToString(), true);
            SessionFacade.USERNAME = username;
            SessionFacade.ROLE = roles;
            Response.Redirect(FormsAuthentication.GetRedirectUrl(username, true));
        }
        else
        {
            lblStatus.Text = "Invalid login for Requested Page";
        }
    }
}