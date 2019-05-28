using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
/// <summary>
/// Summary description for WebService
/// </summary>
/// 
[ScriptService]
public class WebService : System.Web.Services.WebService
{
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public bool IsUserNameTaken(string username)
    {
        using (App_Code.UsersManager um = new App_Code.UsersManager())
        {
            return um.IsNameTaken(username);
        }
    }

}

