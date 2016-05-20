using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IDataAuthentication
/// </summary>
public interface IDataAuthentication
{
     string isValidUser(string uname, string pwd);
     string GetRolesForUser(string username);
}