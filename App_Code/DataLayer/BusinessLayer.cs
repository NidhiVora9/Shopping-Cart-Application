using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BusinessLayer
/// </summary>
public class BusinessLayer:IBusinessFunctions,IBusinessAuthentication
{
    IDataAccount _idac = null;
    IDataAuthentication _idau = null;
    AdminFunctions _iadf = null;
    public BusinessLayer(IDataAccount idac,IDataAuthentication idau,AdminFunctions iadf)
    {
        _idac = idac;
        _idau = idau;
        _iadf = iadf;
    }
    public BusinessLayer():
        this(GenericFactory<Repository,IDataAccount>.CreateInstance(),
        GenericFactory<Repository,IDataAuthentication>.CreateInstance(),
        GenericFactory<Repository,AdminFunctions>.CreateInstance())

    {

    }


    public List<Products> GetProductsByCategory(string catId)
    {
        List<Products> Plist = null;
        try
        {
            Plist = _idac.GetProductsByCategory(catId);
        }
        catch (Exception)
        {
            throw;
        }
        return Plist;
    }

    public DataTable GetProductDetails(string prodId)
    {
        DataTable dt = null;
        try
        {
            dt = _idac.GetProductDetails(prodId);
        }
        catch (Exception)
        {
            throw;
        }
        return dt;
    }
    public DataTable ShowShoppingCart(Cart myCart)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("PID"));
        dt.Columns.Add(new DataColumn("ProdName"));
        dt.Columns.Add(new DataColumn("qty"));
        dt.Columns.Add(new DataColumn("Price"));
        dt.Columns.Add(new DataColumn("PriceTotal"));
        dt.Columns.Add(new DataColumn("ShippingCost"));
        int totaItems = myCart.list.Count;
        double amount = 0.0;
      for(int nItems=0;nItems<totaItems;nItems++)
      {
         DataRow dr=dt.NewRow();
         CartItem item=(CartItem)myCart.list[nItems];
        
         dr["PID"] = item.PID.ToString();
         dr["ProdName"] = item.PName.ToString();
         dr["Price"] = item.Price;
         dr["qty"] = item.Qty;
         dr["ShippingCost"] = item.ShippingCost;
          double rowPrice=(Double.Parse(item.Price)*Double.Parse(item.Qty))+Double.Parse(item.ShippingCost);
         dr["PriceTotal"] = rowPrice.ToString();
         amount = amount + rowPrice;
       dt.Rows.Add(dr);
      }
      DataRow dr1 = dt.NewRow();
      dr1["PriceTotal"]= amount.ToString();
      dt.Rows.Add(dr1);
      return dt;
    }

    public string isValidUser(string uname, string pwd)
    {
        string username="";
        try
        {
            username = _idau.isValidUser(uname, pwd);
        }
        catch (Exception)
        {
            throw;
        }
        return username;
    }

    public bool ChangePassword(string uname, string oldpwd, string newpwd)
    {
        throw new NotImplementedException();
    }


    public DataTable GetCustomerInfo(string username)
    {
        DataTable dt = null;
        try
        {
            dt = _idac.GetCustomerInfo(username);
        }
        catch (Exception)
        {
            throw;
        }
        return dt;
    }


    public int UpdateCustomerInfo(string uid, string street, string city, string state, string zipcode, string ccnum, string cctype, string expdate, string email)
    {
        int res = 0;
        try
        {
            res=_idac.UpdateCustomerInfo(uid,street,city,state,zipcode,ccnum,cctype,expdate,email);
        }
        catch (Exception)
        {
            throw;
        }
        return res;
    }


    public int RegisterCustomer(string uid, string fname, string lname, string street, string city, string state, string zipcode, string ccnum, string cctype, string expdate, string email)
    {
        int res = 0;
        try
        {
            res = _idac.RegisterCustomer(uid, fname, lname, street, city, state, zipcode, ccnum, cctype, expdate, email);
        }
        catch (Exception)
        {
            throw;
        }
        return res;
    }


    public bool checkUsername(string username)
    {

        bool res = false;
        try
        {
            res = _idac.checkUsername(username);
        }
        catch (Exception)
        {
            throw;
        }
        return res;
    }


    public int RegisterUsers(string username, string Password, string PHint, string PAns)
    {
        int res = 0;
        try
        {
            res = _idac.RegisterUsers(username, Password, PHint, PAns);
        }
        catch (Exception)
        {
            throw;
        }
        return res;
    }


    public string GetRolesForUser(string username)
    {
        string roles = "";
        try
        {
            roles = _idau.GetRolesForUser(username);
        }
        catch (Exception)
        {
            throw;
        }
        return roles;
    }


    public DataTable getProductCategories()
    {
        DataTable dt = null;
        try
        {
            dt = _iadf.getProductCategories();
        }
        catch (Exception)
        {
            throw;
        }
        return dt;
    }


    public int InsertProducts(string CatID, string ProductSDesc, string ProductLDesc, string ProductImage, string Price, string InStock, string Inventory, string ShippingCost)
    {
        int res = 0;
        try
        {
            res = _iadf.InsertProducts(CatID, ProductSDesc, ProductLDesc, ProductImage, Price, InStock, Inventory,ShippingCost);
        }
        catch (Exception)
        {
            throw;
        }
        return res;
    }


    public string getCategoryDesc(string catID)
    {
        string catDesc = "";
        try
        {
            catDesc = _iadf.getCategoryDesc(catID);
        }
        catch (Exception)
        {
            throw;
        }
        return catDesc;
    }


    public int UpdateProducts(string ProductSDesc, string ProductLDesc, string ProductImage, string Price, string InStock, string Inventory, string pid)
    {
        int res = 0;
        try
        {
            res = _iadf.UpdateProducts( ProductSDesc, ProductLDesc, ProductImage, Price, InStock, Inventory, pid);
        }
        catch (Exception)
        {
            throw;
        }
        return res;
    }


    public List<Products> GetProductsBySearch(string ProdName)
    {
        List<Products> Plist = null;
        try
        {
            Plist = _idac.GetProductsBySearch(ProdName);
        }
        catch (Exception)
        {
            throw;
        }
        return Plist;
    }


    public DataTable DisplayUsers()
    {
        DataTable dt = null;
        try
        {
            dt = _iadf.DisplayUsers();
        }
        catch (Exception)
        {
            throw;
        }
        return dt;
    }

    public DataTable DisplayRoles()
    {
        DataTable dt = null;
        try
        {
            dt = _iadf.DisplayRoles();
        }
        catch (Exception)
        {
            throw;
        }
        return dt;
    }

    public int RegisterRoles(string userId, string roleId)
    {
        int rows = 0;
        try
        {
            rows = _iadf.RegisterRoles(userId, roleId);
        }
        catch (Exception)
        {
            throw;
        }
        return rows;
    }

    public int RegisterNewRole(string role, string RoleDescription)
    {
        int rows = 0;
        try
        {
            rows = _iadf.RegisterNewRole(role, RoleDescription);
        }
        catch (Exception)
        {
            throw;
        }
        return rows;
    }




    //public DataTable getMenuItems(string MenuParentId)
    //{
    //    DataTable dt = null;
    //    try
    //    {
    //        dt = _idac.getMenuItems(MenuParentId);
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }
    //    return dt;
    //}
}