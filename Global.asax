<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
      

    }
    
   void Application_AuthenticateRequest(Object sender, EventArgs e)
    {
       if (Request.IsAuthenticated)
       {
          
           string cookieName = FormsAuthentication.FormsCookieName;
           HttpCookie authCookie = Context.Request.Cookies[cookieName];
           if (null == authCookie)
           {
               return;  

           }
           FormsAuthenticationTicket authTicket = null;
           try
           {
               authTicket = FormsAuthentication.Decrypt(authCookie.Value);
           }
           catch (Exception ex)
           {
               return;  

           }
           if (null == authTicket)
               return; 

           string roles = authTicket.UserData;
           string[] roleListArray = roles.Split(new char[] { '|' });
           HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(User.Identity, roleListArray);

       }
            
        
    }
    void Application_End(object sender, EventArgs e) 
    {
       

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
    public static void RegisterRoutes(System.Web.Routing.RouteCollection routes)
    {
    }
      
</script>
