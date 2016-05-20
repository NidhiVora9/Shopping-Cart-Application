using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IBusinessAuthentication
/// </summary>
public interface IBusinessAuthentication
{
    string isValidUser(string uname, string pwd);
    bool ChangePassword(string uname, string oldpwd, string newpwd);
    string GetRolesForUser(string username);
}