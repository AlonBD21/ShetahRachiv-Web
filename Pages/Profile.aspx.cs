using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using App_Code;

public partial class Pages_Profile : System.Web.UI.Page
{
    protected string username;
    protected int id;
    protected User user;
    protected string mainErr;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = int.Parse(Request.QueryString["id"] ?? "-1");
        if (id < -0 || id != AppCode.GetSesID(Session))
        {
            Response.Redirect(".");
        }
        using (UsersManager db = new UsersManager())
        {
            user = db.GetUserFromID(id);
        }
        if (user == null)
        {
            Response.Redirect(".");
        }
        switch (user.gender){
            case 0:
                adminTag.InnerText = "מנהל אתר";
                break;
            case 1:
                adminTag.InnerText = "מנהלת אתר";
                break;
            case 2:
                adminTag.InnerText = "מנהל\\ת אתר";
                break;
                
        }
        adminTag.Visible = user.isAdmin;
        username = user.username;
        DataBind();

        string sesUsername = AppCode.GetSesUsrName(Session);
        if (sesUsername != null)
        {
            if (user.username.Equals(sesUsername))
            {
                mainErr = "";
                NameValueCollection f = Request.Form;
                if (f["submit"] != null)
                {

                    int gender = int.Parse(f["gender"] ?? "2");
                    bool[] styles = new bool[4];

                    styles[0] = f["dj"] != null;
                    styles[1] = f["tr"] != null;
                    styles[2] = f["am"] != null;
                    styles[3] = f["dh"] != null;
                    User newUser = new User(user.id, user.username, user.pass, f["txtEmail"], f["txtFullname"], gender, styles[0], styles[1], styles[2], styles[3], f["txtMoto"], user.isActive, user.isAdmin);
                    using (UsersManager db = new UsersManager())
                    {
                        db.UpdateUser(newUser);
                        user = newUser;
                    }
                    AppCode.UserLoggedIn(user,Session,Application);
                    AppCode.UserCountDown(Application);
                    Response.Redirect(Request.RawUrl);

                }
                else
                {
                }
            }
        }
    }
}