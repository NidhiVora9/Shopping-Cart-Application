using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewCustomerReg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                string uname = txtUsername.Text;
                string fname=txtFirstName.Text;
                string lname=txtLastName.Text;
                string street=txtAddress.Text;
                string city=txtCity.Text;
                string state=txtState.Text;
                string zipcode=txtZipcode.Text;
                string email=txtEmail.Text;
                string ccnum=txtCCNumber.Text;
                string expdate=txtCCExpiration.Text;
                string cctype=ddlCCType.SelectedItem.ToString();
                string password=txtPW.Text;
                string phint=txtPWHintQ.Text;
                string pAns=txtPWHintA.Text;
                IBusinessFunctions ibf = GenericFactory<BusinessLayer, IBusinessFunctions>.CreateInstance();
               IBusinessAuthentication ibu=GenericFactory<BusinessLayer,IBusinessAuthentication>.CreateInstance();
                bool isvalidUsername = ibf.checkUsername(uname);
                if (isvalidUsername)
                {
                    lblStatus.Text = "Please choose a different Username as this already exists";
                    throw new Exception("duplicate username");
                }
                else
                {
                    int regusers = ibf.RegisterUsers(uname, password, phint, pAns);
                    string userId = ibu.isValidUser(uname, password);
                    int rows_affected = ibf.RegisterCustomer(userId, fname, lname, street, city, state, zipcode, ccnum, cctype, expdate, email);
                    if(rows_affected>0)
                    {
                        SessionFacade.CUSTOMERID = userId;
                        Response.Redirect("ConfirmCheckOut.aspx");
                    }
                }
            }
            catch(Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }
    }
}