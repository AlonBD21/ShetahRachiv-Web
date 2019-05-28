using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

/// <summary>
/// Summary description for AppCode
/// </summary>
namespace App_Code
{
    public class AppCode
    {
        private static readonly string APP_USERSIN = "usersIn";

        private static readonly string SES_ID_int = "user_id";
        private static readonly string SES_USRNAME_string = "username";
        private static readonly string SES_GENDER_int = "gender";
        private static readonly string SES_ISADMIN_bool = "admin";

        public static int GetSesID(HttpSessionState session)
        {
            if (session[SES_ID_int] == null)
            {
                return -1;
            }
            else return int.Parse(session[SES_ID_int].ToString());
        }

        public static String GetSesUsrName(HttpSessionState session)
        {
            return (String)session[SES_USRNAME_string];
        }
        public static int GetSesGender(HttpSessionState session)
        {
            return (int)session[SES_GENDER_int];
        }
        public static bool GetSesIsAdmin(HttpSessionState session)
        {
            if (session[SES_ISADMIN_bool] == null) return false;
            return (bool)session[SES_ISADMIN_bool];
        }

        public static void UserLoggedIn(int id,User user, HttpSessionState session, HttpApplicationState app)
        {
            session["user_id"] = id;
            session["username"] = user.username;
            session["gender"] = user.gender;
            session["admin"] = user.isAdmin;
            UserCountUp(app);
        }
        public static void UserLoggedIn(User user, HttpSessionState session, HttpApplicationState app)
        {
            UserLoggedIn(user.id, user, session, app);
        }
        public static void UserCountUp(HttpApplicationState app)
        {
            UserCountSet(app);
            app[APP_USERSIN] = (int)app[APP_USERSIN] + 1;
        }
        public static void UserCountDown(HttpApplicationState app)
        {
            UserCountSet(app);
            app[APP_USERSIN] = (int)app[APP_USERSIN] - 1;
        }
        public static void UserCountSet(HttpApplicationState app)
        {
            if (app[APP_USERSIN] == null) app[APP_USERSIN] = 0;
        }
        public static int GetUsersIn(HttpApplicationState application)
        {
            return (int)application[APP_USERSIN];
        }
    }
}