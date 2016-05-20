using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataAccess
/// </summary>
public class DataAccess:IDataAccess
{
    public static string CONNSTR = ConfigurationManager.ConnectionStrings["ShoppingApplication"].ConnectionString;
	public DataAccess()
	{
	}

    public object GetScalar(string sql)
    {
        SqlConnection conn = new SqlConnection(CONNSTR);
        object obj = null;
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            obj = cmd.ExecuteScalar();
            conn.Close();
        }
        catch(Exception ex)
        {
            throw ex;
        }
        finally
        {
            conn.Close();
        }
        return obj;
    }

    //public DataSet GetDataSet(string sql)
    //{
    //    SqlConnection conn = new SqlConnection(CONNSTR);
    //    DataSet ds = null;
    //    try
    //    {
    //        conn.Open();
    //        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
    //        da.Fill(ds);
    //        conn.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        conn.Close();
    //    }
    //    return ds;

    //}

    public int InsOrUpdOrDel(string sql)
    {
        SqlConnection conn = new SqlConnection(CONNSTR);
        int rows_affected = 0;
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            rows_affected = cmd.ExecuteNonQuery();
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
        return rows_affected;

    }



    public DataTable GetDataTable(string sql)
    {
        SqlConnection conn = new SqlConnection(CONNSTR);
        DataTable dt = new DataTable();
        try
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
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
        return dt;
    }
}