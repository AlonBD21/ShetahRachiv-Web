using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Configuration;

/// <summary>
/// Summary description for UsersManager
/// </summary>
namespace App_Code
{
    public class UsersManager : IDisposable
    {
        private SqlConnection con;

        public UsersManager()
        {
            string cs = ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString;
            con = new SqlConnection(cs);
            con.Open();
        }

        public DataTable GetAllUsers()
        {
            DataTable data = new DataTable();
            string sql = "SELECT * FROM [Users]";
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, con))
            {
                adapter.Fill(data);
            }
            return data;
        }
        public void DeleteUser(int id)
        {
            string sql = "DELETE FROM [Users] WHERE [user_id]=@id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
        public void UpdateUser(User user)
        {
            string sql = @"UPDATE [Users] 
SET [user_name]=@username, [password]=@pass, [email]=@email, [name]=@name, [gender]=@gender, 
[stylesDJ]=@stylesDJ, [stylesTR]=@stylesTR, [stylesAM]=@stylesAM, [stylesDH]=@stylesDH, [bio]=@bio, [is_active]=@active, [is_admin]=@admin WHERE [user_id]=@id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", user.id);

            cmd.Parameters.AddWithValue("@username", user.username);
            cmd.Parameters.AddWithValue("@pass", user.pass);
            cmd.Parameters.AddWithValue("@email", user.email);
            cmd.Parameters.AddWithValue("@name", user.name);
            cmd.Parameters.AddWithValue("@gender", user.gender);
            cmd.Parameters.AddWithValue("@stylesDJ", user.dj);
            cmd.Parameters.AddWithValue("@stylesTR", user.tr);
            cmd.Parameters.AddWithValue("@stylesAM", user.am);
            cmd.Parameters.AddWithValue("@stylesDH", user.dh);
            cmd.Parameters.AddWithValue("@bio", user.bio);
            cmd.Parameters.AddWithValue("@active", user.isActive);
            cmd.Parameters.AddWithValue("@admin", user.isAdmin);

            cmd.ExecuteNonQuery();
        }

        public int GetGender(int userId)
        {
            string sql = "SELECT [gender] FROM [Users] WHERE [user_id]=@id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", userId);
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return (int)reader["gender"];
                }
                return 2;
            }
        }

        public User GetUserFromID(int id)
        {
            string sql = "SELECT * FROM [Users] WHERE [user_id]=@id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);
            using (DbDataReader data = cmd.ExecuteReader())
            {
                if (data.Read())
                {
                    return new User(data);
                }
                else return null;
            }
        }

        public User GetUserLogin(string userName, string password)
        {
            string sql = "SELECT * FROM [Users] WHERE [user_name]=@name";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@name", userName);
            using (DbDataReader data = cmd.ExecuteReader())
            {
                if (data.Read())
                {
                    if (password == data["password"].ToString())
                    {
                        return new User(data);
                    }
                }
            }
            return null;
        }
        public bool IsUserActive(int userID)
        {
            string sql = "select [is_active] from [Users] where [user_id]=@ID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ID", userID);
            using (DbDataReader data = cmd.ExecuteReader())
            {
                if (data.Read())
                {
                    return (bool)data["is_active"];
                }
                return false;
            }
        }
        public bool IsUserAdmin(int userID)
        {
            string sql = "select [is_admin] from [Users] where [user_id]=@ID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ID", userID);
            using (DbDataReader data = cmd.ExecuteReader())
            {
                if (data.Read())
                {
                    return (bool)data["is_admin"];
                }
                return false;
            }
        }
        public bool IsNameTaken(string userName)
        {
            SqlCommand command = new SqlCommand("SELECT [user_id] FROM [Users] WHERE LOWER([user_name])=LOWER(@name)", con);
            command.Parameters.AddWithValue("@name", userName);
            using (DbDataReader data = command.ExecuteReader())
            {
                if (data.Read())
                {
                    return true;
                }
            }
            return false;
        }
        public int AddUserToDB(User user)
        {
            string sql = "INSERT INTO [Users] ([user_name],[password],[email],[name],[gender],[stylesDJ],[stylesTR],[stylesAM],[stylesDH],[bio])" +
                " VALUES (@username, @pass, @email, @name, @gender, @dj, @tr, @am, @dh, @bio); SELECT @@IDENTITY as [ID];";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@username", user.username);
            cmd.Parameters.AddWithValue("@pass", user.pass);
            cmd.Parameters.AddWithValue("@email", user.email);
            cmd.Parameters.AddWithValue("@name", user.name);
            cmd.Parameters.AddWithValue("@gender", user.gender);
            cmd.Parameters.AddWithValue("@dj", user.dj);
            cmd.Parameters.AddWithValue("@tr", user.tr);
            cmd.Parameters.AddWithValue("@am", user.am);
            cmd.Parameters.AddWithValue("@dh", user.dh);
            cmd.Parameters.AddWithValue("@bio", user.bio);

            using(DbDataReader data = cmd.ExecuteReader())
            {
                if (data.Read() ) {
                    return int.Parse(data["ID"].ToString());
                }
            }
            return -1;
        }
        public void Dispose()
        {
            con.Dispose();
        }

    }
}