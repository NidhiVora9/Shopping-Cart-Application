using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IDataAccount
/// </summary>
public interface IDataAccount
{
  
    List<Products> GetProductsByCategory(string catId);
    List<Products> GetProductsBySearch(string ProdName);
    DataTable GetProductDetails(string prodId);
    DataTable GetCustomerInfo(string username);
    int UpdateCustomerInfo(string uid,string street, string city, string state, string zipcode, string ccnum, string cctype, string expdate, string email);
    int RegisterUsers(string username, string Password, string PHint, string PAns);
    int RegisterCustomer(string uid,string fname,string lname, string street, string city, string state, string zipcode, string ccnum, string cctype, string expdate, string email);
    bool checkUsername(string username);
    //DataTable getMenuItems(string MenuParentId);

}