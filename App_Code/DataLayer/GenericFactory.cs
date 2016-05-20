using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GenericFactory
/// </summary>
public class GenericFactory<T,I>
    where T:I   
{
	GenericFactory()
	{
	}
    public static I CreateInstance(params object[] args)
    {
        return (I)Activator.CreateInstance(typeof(T), args);
    }
}