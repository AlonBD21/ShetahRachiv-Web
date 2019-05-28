using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using App_Code;

public partial class Register : System.Web.UI.Page
{
    protected string userErr;
    protected string mainErr;
    protected string passErr;
    protected void Page_Load(object sender, EventArgs e)
    {
        mainErr = "";
        NameValueCollection f = Request.Form;
        if (f["submit"] != null)
        {
            bool lookinGood = true;

            if (!f["txtVerify"].Equals(f["txtPass"]))
            {
                lookinGood = false;
                mainErr += "סיסמאות אינן תואמות. ";
            }
            if (f["txtPass"].Length <= 5)
            {
                lookinGood = false;
                mainErr += "הסיסמה חייבת להיות בת 6 ספרות לפחות. ";

            }
            if (f["txtUser"].Contains(" "))
            {
                lookinGood = false;
                mainErr += "שם המשתמש לא יכול להכיל רווחים. ";
            }
            using (UsersManager db = new UsersManager())
            {
                if (db.IsNameTaken(f["txtUser"]))
                {
                    lookinGood = false;
                    mainErr = "שם המשתמש כבר תפוס";
                }
            }

            if (lookinGood)
            {
                int id;

                int gender = int.Parse(f["gender"] ?? "2");
                bool[] styles = new bool[4];

                styles[0] = f["dj"] != null;
                styles[1] = f["tr"] != null;
                styles[2] = f["am"] != null;
                styles[3] = f["dh"] != null;
                User user = new User(0, f["txtUser"], f["txtPass"], f["txtEmail"], f["txtFullname"], gender, styles[0], styles[1], styles[2], styles[3], f["txtMoto"], true, false);
                using (UsersManager db = new UsersManager())
                {
                    id = db.AddUserToDB(user);
                }
                if (id != -1)
                {
                    AppCode.UserLoggedIn(id,user, Session, Application);
                    Response.Redirect(".");
                }
                else
                {
                    Response.Write("REGISTERATION FAILED");
                }
            }
        }
    }
}