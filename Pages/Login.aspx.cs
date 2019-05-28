using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using App_Code;
public partial class Login : System.Web.UI.Page
{
    protected string focusID;
    protected string error;
    protected void Page_Load(object sender, EventArgs e)
    {
        NameValueCollection f = Request.Form;
        error = "";
        if(f["submit"] != null)
        {
            User user;
            bool isExist;

            string inUsr = f["username"];
            string inPas = f["password"];

            using (UsersManager db = new UsersManager())
            {
                user = db.GetUserLogin(inUsr, inPas);
                isExist = db.IsNameTaken(inUsr);
            }

            if (user != null)
            {
                if (user.isActive)
                {
                    AppCode.UserLoggedIn(user, Session, Application);
                    Response.Redirect(".");
                }
                else
                {
                    error = "המשתמש חסום";
                    focusID = "";
                }
            }
            else
            {
                if (isExist)
                {
                    error = "סיסמה שגויה";
                    focusID = "txtPass";
                }
                else
                {
                    error = "שם משתמש או סיסמה שגויים";
                    focusID = "txtUser";
                }
            }
        }
    }
}
