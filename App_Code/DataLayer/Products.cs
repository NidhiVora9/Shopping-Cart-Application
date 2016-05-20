using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Products
/// </summary>
public class Products:IEntity
{
    public string ProductID { get; set; }
    public string CategoryID { get; set; }
    public string ProductSDesc { get; set; }
    public string ProductLDesc { get; set; }
    public string Price { get; set; }
    public string ProductImage { get; set; }
    public string Inventory { get; set; }
    public string ShippingCost { get; set; }


    public void SetFields(DataRow dr)
    {
        this.ProductID = (string)dr["ProductID"].ToString();
        this.CategoryID = (string)dr["CatID"].ToString();
        this.ProductSDesc = (string)dr["ProductSDesc"].ToString();
        this.ProductLDesc = (string)dr["ProductLDesc"].ToString();
        this.Price = (string)dr["Price"].ToString();
        this.ProductImage = (string)dr["ProductImage"].ToString();
        this.Inventory = (string)dr["Inventory"].ToString();
        this.ShippingCost = (string)dr["ShippingCost"].ToString();
    }
}
