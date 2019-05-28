using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
public partial class MasterPage : System.Web.UI.MasterPage
{
    protected string usersIn;
    string[] welcomes = { "ברוך הבא", "ברוכה הבאה", "ברוך\\ה הבא\\ה" };
    protected void Page_Load(object sender, EventArgs e)
    {
        AppCode.UserCountSet(Application);
        usersIn = (AppCode.GetUsersIn(Application)).ToString();

        adminLink.Visible = false;
        welcome.Visible = false;

        if (AppCode.GetSesUsrName(Session) != null)
        {
            hello.InnerText = welcomes[AppCode.GetSesGender(Session)];
            username.InnerText = AppCode.GetSesUsrName(Session);
            enter.Visible = false;
            logout.Visible = true;
            welcome.Visible = true;

            profileLink.HRef = "Profile.aspx?id=" + AppCode.GetSesID(Session);

            if (AppCode.GetSesIsAdmin(Session))
            {
                adminLink.Visible = true;
            }
        }
        else
        {
            welcome.Visible = false;
            logout.Visible = false;
            enter.Visible = true;
        }
    }


    protected void Logout_Btn(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect(".");
    }
}
