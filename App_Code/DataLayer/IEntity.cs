using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IEntity
/// </summary>
public interface IEntity
{
    void SetFields(DataRow dr);
}