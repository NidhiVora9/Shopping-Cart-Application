using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IBusinessFunctions
/// </summary>
public interface IBusinessFunctions
{
    DataTable ShowShoppingCart(Cart myCart);
    List<Products> GetProductsByCategory(string catId);
    List<Products> GetProductsBySearch(string ProdName);
    DataTable GetProductDetails(string prodId);
    DataTable GetCustomerInfo(string username);
    int UpdateCustomerInfo(string uid,string street, string city, string state, string zipcode, string ccnum, string cctype, string expdate, string email);
    int RegisterCustomer(string uid, string fname, string lname, string street, string city, string state, string zipcode, string ccnum, string cctype, string expdate, string email);
    bool checkUsername(string username);
    int RegisterUsers(string username, string Password, string PHint, string PAns);
    DataTable getProductCategories();
    int InsertProducts(string CatID, string ProductSDesc, string ProductLDesc, string ProductImage, string Price, string InStock, string Inventory,string ShippingCost);
    string getCategoryDesc(string catID);
    int UpdateProducts(string ProductSDesc, string ProductLDesc, string ProductImage, string Price, string InStock, string Inventory, string pid);
    DataTable DisplayUsers();
    DataTable DisplayRoles();
    int RegisterRoles(string userId, string roleId);
    int RegisterNewRole(string role, string RoleDescription);
    //DataTable getMenuItems(string MenuParentId);
}