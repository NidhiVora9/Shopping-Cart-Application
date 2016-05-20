using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    string ParId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(SessionFacade.USERNAME!=null)
            {
                string username = SessionFacade.USERNAME.First().ToString().ToUpper()+SessionFacade.USERNAME.Substring(1);
                lbluser.Text = "Welcome " +username;
            }
            if (SessionFacade.ROLE == "Admin|Customer")
            {
                ParId = "1";
            }
            else if (SessionFacade.ROLE == "ElectronicsManager" || SessionFacade.ROLE == "LuggageManager"||
                SessionFacade.ROLE == "BeautyManager" || SessionFacade.ROLE == "SportsManager"
            || SessionFacade.ROLE == "KitchenManager")
            {
                ParId = "7";
            }
            else
            {
                ParId = "10";
            }
            //GetMenu(ParId);
        }
    }
   
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("DisplayProducts.aspx?search=" + txtsearch.Text.Trim());
    }

    //private void GetMenu(string MenuParentID)
    //{
    //    DataTable dt = new DataTable();
    //    IBusinessFunctions ibf = GenericFactory<BusinessLayer, IBusinessFunctions>.CreateInstance();
    //    //dt = ibf.getMenuItems(ParId);     
    //    for(int i=0;i<dt.Rows.Count;i++)
    //    {
    //        NavMenu.Items.Add(new MenuItem(dt.Rows[i]["DisplayText"].ToString(),dt.Rows[i]["MenuID"].ToString(),"","~/"+dt.Rows[i]["NavigateUrl"].ToString()));          
    //    }
    //    if (ParId == "1")
    //    {

    //        string subPrentId = "3";
    //        DataTable dt1 = ibf.getMenuItems(subPrentId);
    //        for (int i = 0; i < dt1.Rows.Count; i++)
    //        {
    //            MenuItem subitems = new MenuItem(dt1.Rows[i]["DisplayText"].ToString(), dt1.Rows[i]["MenuID"].ToString(), "", "~/" + dt1.Rows[i]["NavigateUrl"].ToString());
    //            NavMenu.FindItem(subPrentId).ChildItems.Add(subitems);
    //        }
            
    //    }
       
    //}
}
