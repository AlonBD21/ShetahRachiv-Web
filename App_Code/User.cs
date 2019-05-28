using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace App_Code
{
    public class User
    {
        public int id { get; private set; }
        public string username { get; private set; }
        public string pass { get; private set; }
        public string email { get; private set; }
        public string name { get; private set; }
        public int gender { get; private set; }
        public bool dj { get; private set; }
        public bool tr { get; private set; }
        public bool am { get; private set; }
        public bool dh { get; private set; }
        public string bio { get; private set; }
        public bool isActive { get; private set; }
        public bool isAdmin { get; private set; }

        public User(int id, string username, string pass, string email, string name, int gender,
            bool dj, bool tr, bool am, bool dh, string bio, bool isActive, bool isAdmin)
        {
            this.id = id; this.username = username; this.pass = pass;
            this.email = email; this.name = name; this.gender = gender;
            this.dj = dj; this.tr = tr; this.am = am; this.dh = dh;
            this.bio = bio; this.isActive = isActive; this.isAdmin = isAdmin;
        }

        public User(DbDataReader d) : this((int)d["user_id"],
            d["user_name"] as string, d["password"] as string, d["email"] as string, d["name"] as string, (int)d["gender"],
            (bool)d["stylesDJ"], (bool)d["stylesTR"], (bool)d["stylesAM"], (bool)d["stylesDH"], d["bio"] as string, (bool)d["is_active"], (bool)d["is_admin"])
        { }

        internal void PostRegisterUpdate(int id)
        {
            this.id = id;
            this.isAdmin = false;
            isActive = true;
        }
    }
}