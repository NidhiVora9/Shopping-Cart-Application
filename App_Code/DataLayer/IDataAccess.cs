using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IDataAccess
/// </summary>
public interface IDataAccess
{
    object GetScalar(string sql);
   // DataSet GetDataSet(string sql);
    DataTable GetDataTable(string sql);
    int InsOrUpdOrDel(string sql);  
}