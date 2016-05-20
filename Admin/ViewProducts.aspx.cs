﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ViewProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if(!IsPostBack)
        {
            string catID = Request["catID"];
            if (catID == null)
                return;
            catID = Utils.StripPunctuation(catID);
            SessionFacade.CATID = catID;
            try
            {
                IBusinessFunctions ibf = GenericFactory<BusinessLayer, IBusinessFunctions>.CreateInstance();
                List<Products> Plist = ibf.GetProductsByCategory(catID);
                gv1.DataSource = Plist;
                gv1.DataBind();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }
    }
    
   
}