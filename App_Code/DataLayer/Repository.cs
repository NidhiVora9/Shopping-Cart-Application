using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Repository
/// </summary>
public class Repository : IDataAccount,IDataAuthentication,AdminFunctions
{
    IDataAccess _idataAccess = null;
    public Repository(IDataAccess ida)
    {
        _idataAccess = ida;
    }

    public Repository() : this(GenericFactory<DataAccess, IDataAccess>.CreateInstance()) { }

    public List<Products> GetProductsByCategory(string catId)
    {
        List<Products> Plist = null;
        try
        {
            if (Plist == null)
            {
                DataTable dt = GetProductsByCategoryDB(catId);
                Plist = RepositoryHelper.ConvertDataTableToList<Products>(dt);            
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Plist;
    }

    public DataTable GetProductDetails(string prodId)
    {

        DataTable dt =null;
        try
        {
             string sql = "SELECT * FROM  Products WHERE ProductId=" + prodId;
             dt = _idataAccess.GetDataTable(sql);
                

        }
        
        catch (Exception ex)
        {
            throw ex;
        }
        return dt;
    }

    public DataTable GetProductsByCategoryDB(string catID)
    {
        DataTable dt = null;
        try
        {
            string sql = "SELECT * FROM  Products WHERE CatID=" + catID;
            dt = _idataAccess.GetDataTable(sql);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dt;
    }




    public string isValidUser(string uname, string pwd)
    {
        string username="";
        try
        {
            string sql = "select UserID from Users where Username='" +
            uname + "' and Password='" + pwd + "'";
            object obj = _idataAccess.GetScalar(sql);
            if (obj != null)
                username = obj.ToString();
           
        }
        catch
        {
            throw;
        }
        return username;
    }



    public DataTable GetCustomerInfo(string username)
    {
        DataTable dt = null;
        try
        {
            string sql = "SELECT * FROM  CustomerInfos WHERE UserID=" + username;
            dt = _idataAccess.GetDataTable(sql);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dt;
    }


    public int UpdateCustomerInfo(string uid,string street, string city, string state, string zipcode, string ccnum, string cctype, string expdate, string email)
    {
        int res = 0;
        try
        {
              string sql="Update CustomerInfos set Address='" + street + "'," +
                        "City='" + city + "',"
                        + "State='" + state + "',"
                        + "Zipcode='" + zipcode + "',"
                        + "Email='" + email + "',"
                        + "CCNumber='" + ccnum + "',"
                        + "CCType='" + cctype + "',"
                        + "CCExpiration='" + expdate + "'" + "where UserID=" + uid;
              res = _idataAccess.InsOrUpdOrDel(sql);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return res;
    }


    public int RegisterCustomer(string uid, string fname, string lname, string street, string city, string state, string zipcode, string ccnum, string cctype, string expdate, string email)
    {
        int res = 0;
        try
        {
            string sql= "INSERT INTO CustomerInfos (UserID,FirstName,LastName,"
                    + "Address,ZipCode,City,State,CCNumber,CCExpiration,CCType,Email)"
                    + " VALUES (" +
                    uid + "','" + fname + "','" + lname + "','" + street + "','" +
                    zipcode + "','" + city + "','" + state + "','" + ccnum + "','" +
                    expdate + "','" + cctype + "','" + email + "')";
            string sql1="Insert into UserRoles (UserID,RoleID) values("+uid+",2)";

            res = _idataAccess.InsOrUpdOrDel(sql);
            int res1=_idataAccess.InsOrUpdOrDel(sql1);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return res;
    }


    public bool checkUsername(string username)
    {
        bool isValid = false;
        object obj = null;

        try
        {
          string sql=  "select * from Users where Username='" +
                    username + "'";
          obj = _idataAccess.GetScalar(sql);
            if(obj!=null)
            {
                isValid = true;
            }
            else
            {
                isValid = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return isValid;
    }


    public int RegisterUsers(string username, string Password, string PHint, string PAns)
    {
        int res = 0;
        try
        {
            string sql = "INSERT INTO Users (Username,Password,PHint,PAns) VALUES ('" +
                    username + "','" + Password + "','" + PHint + "','" + PAns + "')";

            res = _idataAccess.InsOrUpdOrDel(sql);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return res;
    }


    public string GetRolesForUser(string username)
    {
        string roles = "";
        string connStr = ConfigurationManager.ConnectionStrings["ShoppingApplication"].ConnectionString;
        SqlConnection conn = new SqlConnection(connStr);
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("GetUserRoles", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Username", username));
            SqlDataReader reader = cmd.ExecuteReader();
            ArrayList roleList = new ArrayList();
            while(reader.Read())
            {
                roles += reader["Role"].ToString() + "|";
                               
            }
            if (roles != "")
            {
                roles = roles.Substring(0, roles.Length - 1);

            }
            conn.Close(); 
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            conn.Close();
        }
        return roles;

    }

    public DataTable getProductCategories()
    {
        DataTable dt = null;
        try
        {
            string sql = "select * from ProductCategories";
            dt = _idataAccess.GetDataTable(sql);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dt;
    }


    public int InsertProducts(string CatID, string ProductSDesc, string ProductLDesc, string ProductImage, string Price, string InStock, string Inventory, string ShippingCost)
    {
        int rows = 0;
        try
        {
            string sql = "Insert into Products (CatID,ProductSDesc,ProductLDesc,ProductImage,Price,InStock,Inventory,ShippingCost) Values (" +
                CatID+ ",'" + ProductSDesc + "','" + ProductLDesc + "','" +
                ProductImage + "'," + Price + "," + InStock + "," + Inventory + "," + ShippingCost + ")";
            rows = _idataAccess.InsOrUpdOrDel(sql);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return rows;
    }


    public string getCategoryDesc(string catID)
    {
        string catDes = "";
        try
        {
            string sql = "Select CatDesc from ProductCategories where CatID=" +
                        catID;
            object obj = _idataAccess.GetScalar(sql);
            if(obj!=null)
            {
               catDes= obj.ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return catDes;
    }


    public int UpdateProducts(string ProductSDesc, string ProductLDesc, string ProductImage, string Price, string InStock, string Inventory, string pid)
    {
        int rows = 0;
        try
        {
            string sql = "Update Products Set ProductSDesc='" +
                ProductSDesc + "',Inventory=" + Inventory + ",ProductLDesc='" + ProductLDesc + "',Price=" +
                Price + ",ProductImage='" + ProductImage + "',InStock=" + InStock + " where ProductID=" +
                pid;
            rows = _idataAccess.InsOrUpdOrDel(sql);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return rows;
    }


    public List<Products> GetProductsBySearch(string ProdName)
    {
        DataTable dt = null;
        List<Products> Plist = null;
        try
        {
            if (Plist == null)
            {
                string sql = "Select * from Products where ProductSDesc LIKE '%" + ProdName + "%'";
                dt = _idataAccess.GetDataTable(sql);
                Plist = RepositoryHelper.ConvertDataTableToList<Products>(dt);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Plist;
    }




    public DataTable DisplayUsers()
    {
        DataTable dt = null;
        try
        {
            string sql = "select * from Users";
            dt = _idataAccess.GetDataTable(sql);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dt;
    }

    public DataTable DisplayRoles()
    {
        DataTable dt = null;
        try
        {
            string sql = "select * from DefinedRoles";
            dt = _idataAccess.GetDataTable(sql);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dt;
    }

    public int RegisterRoles(string userId, string roleId)
    {
        int rows = 0;
        try
        {
           
            string sql = "Insert into UserRoles(UserID,RoleID) values('"
                + userId + "','" + roleId + "')";
            rows = _idataAccess.InsOrUpdOrDel(sql);
        }
       catch (Exception ex)
        {
            throw ex;
        }
        return rows;
    }

    public int RegisterNewRole(string role, string RoleDescription)
    {
        int rows = 0;
        int roleId = 0;
        try
        {
            string sql1 = "Select max(RoleID) from DefinedRoles";
            object obj = _idataAccess.GetScalar(sql1);
            if(obj!=null)
            {
                roleId = Int16.Parse(obj.ToString());
            }
            roleId += 1;
            string sql = "Insert into DefinedRoles(RoleID,Role,RoleDescription) values('"
            +roleId+"','"+ role + "','" + RoleDescription + "')";
            rows = _idataAccess.InsOrUpdOrDel(sql);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return rows;
    }


    //public DataTable getMenuItems(string MenuParentId)
    //{
    //    DataTable dt=null;
    //    try
    //    {
    //        string sql = "Select * from Menus where ParentMenuID=" + MenuParentId;
    //        dt = _idataAccess.GetDataTable(sql);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return dt;
    //}
}