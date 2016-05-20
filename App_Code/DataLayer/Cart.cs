using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Cart
/// </summary>
/// 
public class CartItem:ICloneable
{
    public string PID;
    public string PName;
    public string Price;
    public string Qty;
    public string cartId;
    public string ShippingCost;
    public object Clone()
    {
        return MemberwiseClone();
    }
}
public class Cart:ICloneable

{
    public List<CartItem> list = new List<CartItem>();
  //public ArrayList list = new ArrayList(20);

    public Cart() { }

    private Cart(List<CartItem> items)
    {
        foreach(CartItem i in items)
        {
            list.Add((CartItem)i.Clone());
        }

    }

    public object Clone()
    {
        return new Cart(this.list);
    }

}