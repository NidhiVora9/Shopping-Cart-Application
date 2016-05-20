using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdminFunctions
/// </summary>
public interface AdminFunctions
{
    DataTable getProductCategories();
    int InsertProducts(string CatID, string ProductSDesc, string ProductLDesc, string ProductImage, string Price, string InStock, string Inventory, string ShippingCost);
    string getCategoryDesc(string catID);
    int UpdateProducts(string ProductSDesc, string ProductLDesc, string ProductImage, string Price, string InStock, string Inventory, string pid);
    DataTable DisplayUsers();
    DataTable DisplayRoles();
    int RegisterRoles(string userId, string roleId);
    int RegisterNewRole(string role, string RoleDescription);
}