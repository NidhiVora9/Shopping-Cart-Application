using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SessionFacade
/// </summary>
public class SessionFacade
{
    static string _CATID = "CATID";
    public static string CATID
    {
        get
        {
            string res = null;
            if (HttpContext.Current.Session[_CATID] != null)
                res = (string)HttpContext.Current.Session[_CATID];
            return res;
        }
        set
        {
            HttpContext.Current.Session[_CATID] = value;
        }
    }
   
    static readonly string _PRICE = "PRICE";
    public static string PRICE
    {
        get
        {
            string res = null;
            if (HttpContext.Current.Session[_PRICE] != null)
                res = (string)HttpContext.Current.Session[_PRICE];
            return res;
        }
        set
        {
            HttpContext.Current.Session[_PRICE] = value;
        }
    }
    static readonly string _PRODNAME = "PRODNAME";
    public static string PRODNAME
    {
        get
        {
            string res = null;
            if (HttpContext.Current.Session[_PRODNAME] != null)
                res = (string)HttpContext.Current.Session[_PRODNAME];
            return res;
        }
        set
        {
            HttpContext.Current.Session[_PRODNAME] = value;
        }
    }
    static readonly string _PRODUCTID = "PRODUCTID";
    public static string PRODUCTID
    {
        get
        {
            string res = null;
            if (HttpContext.Current.Session[_PRODUCTID] != null)
                res = (string)HttpContext.Current.Session[_PRODUCTID];
            return res;
        }
        set
        {
            HttpContext.Current.Session[_PRODUCTID] = value;
        }
    }
    static readonly string _USERNAME = "USERNAME";
    public static string USERNAME
    {
        get
        {
            string res = null;
            if (HttpContext.Current.Session[_USERNAME] != null)
                res = (string)HttpContext.Current.Session[_USERNAME];
            return res;
        }

        set
        {
            HttpContext.Current.Session[_USERNAME] = value;
        }
    }
    static readonly string _CUSTOMERID = "CUSTOMERID";
    public static string CUSTOMERID
    {
        get
        {
            string res = null;
            if (HttpContext.Current.Session[_CUSTOMERID] != null)
                res = (string)HttpContext.Current.Session[_CUSTOMERID];
            return res;
        }

        set
        {
            HttpContext.Current.Session[_CUSTOMERID] = value;
        }
    }
    static readonly string _SHIPPING = "SHIPPING";
    public static string SHIPPING
    {
        get
        {
            string res = null;
            if (HttpContext.Current.Session[_SHIPPING] != null)
                res = (string)HttpContext.Current.Session[_SHIPPING];
            return res;
        }

        set
        {
            HttpContext.Current.Session[_SHIPPING] = value;
        }
    }
    static readonly string _CUSTOMERORDERNUM = "CUSTOMERORDERNUM";
    public static string CUSTOMERORDERNUM
    {
        get
        {
            string res = null;
            if (HttpContext.Current.Session[_CUSTOMERORDERNUM] != null)
                res = (string)HttpContext.Current.Session[_CUSTOMERORDERNUM];
            return res;
        }

        set
        {
            HttpContext.Current.Session[_CUSTOMERORDERNUM] = value;
        }
    }
    static readonly string _ROLE = "ROLE";
    public static string ROLE
    {
        get
        {
            string res = null;
            if (HttpContext.Current.Session[_ROLE] != null)
                res = (string)HttpContext.Current.Session[_ROLE];
            return res;
        }

        set
        {
            HttpContext.Current.Session[_ROLE] = value;
        }
    }

}