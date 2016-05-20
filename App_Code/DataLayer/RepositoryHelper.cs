using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RepositoryHelper
/// </summary>
public class RepositoryHelper
{
	public RepositoryHelper()
	{
		
	}
    //public static List<T> ConvertDataSetToList<T>(DataSet ds)
    //   where T:IEntity, new()
    //{
    //    List<T> pList = new List<T>();
    //    foreach(DataRow dr in ds.Tables["Products"].Rows)
    //    {
    //        T p = new T();
    //        p.SetFields(dr);
    //        pList.Add(p);
    //    }
    //    return pList;

    //}
    public static List<T> ConvertDataTableToList<T>(DataTable dt)
       where T : IEntity, new()
    {
        List<T> pList = new List<T>();
        foreach (DataRow dr in dt.Rows)
        {
            T p = new T();
            p.SetFields(dr);
            pList.Add(p);
        }
        return pList;

    }
}