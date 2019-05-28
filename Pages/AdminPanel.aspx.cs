using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;
using System.Data;
using App_Code;
public partial class AdminPanel : System.Web.UI.Page
{
    protected DataTable users;
    protected string mainErr;
    User user;
    int id;
    string username;
    string pass;
    string email;
    bool active;
    bool admin;


    protected void Page_Load(object sender, EventArgs e)
    {
        NameValueCollection f = Request.Form;
        if (!AppCode.GetSesIsAdmin(Session))
        {
            Response.Redirect(".");
        }
        else
        {
            using (UsersManager um = new UsersManager())
            {
                users = um.GetAllUsers();
                if (!um.IsUserAdmin(AppCode.GetSesID(Session)))
                {
                    Response.Redirect(".");
                }
            }
            lv.DataSource = users;
            lv.DataBind();
        }
        if (f["upd"] != null || f["del"] != null)
        {



            if (f["upd"] != null)
            {
                id = int.Parse(f["upd"].ToString());
                string sid = id.ToString();
                username = f["username" + sid];
                pass = f["password" + sid];
                email = f["email" + sid];
                active = f["active" + sid] !=null;
                admin = f["admin" + sid] != null;
                if (pass.Length <= 5)
                {
                    mainErr = "הסיסמה חייבת להיות בת 6 ספרות לפחות. ";
                    return;

                }
                if (username.Contains(" "))
                {
                    mainErr = "שם המשתמש לא יכול להכיל רווחים. ";
                    return;
                }

                using (UsersManager um = new UsersManager())
                {
                    user = um.GetUserFromID(id);
                    um.UpdateUser(new User(user.id, username, pass, email, user.name, user.gender, user.dj, user.tr, user.am, user.dh, user.bio, active, admin));
                    users = um.GetAllUsers();
                    lv.DataBind();
                    Response.Redirect(Request.RawUrl);
                }
            }

            if (f["del"] != null)
            {
                id = int.Parse(f["del"]);
                using (UsersManager um = new UsersManager())
                {
                    um.DeleteUser(id);
                    users = um.GetAllUsers();
                    lv.DataBind();
                    Response.Redirect(Request.RawUrl);
                }

            }
        }
    }
}