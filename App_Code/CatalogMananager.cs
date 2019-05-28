using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CatalogMananager
/// </summary>
namespace App_Code
{
    public class CatalogMananager : IDisposable
    {
        private SqlConnection con;

        public CatalogMananager()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString);
            con.Open();
        }

        public DataTable ChooseBikes(string styleSymbol, int[] manuID, bool[] manuSelect, bool? fullSus)
        {
            DataTable table = new DataTable();
            string sql = @"SELECT [B].[name] as [bike_name], [M].[name] as [manu_name], [style], [fs], [img_name], [url]
 FROM [Bikes] as [B] JOIN [Manus] as [M] ON [M].[manu_id]=[B].[manu]
 WHERE [manu_id] IN (@manus)";

            string end = "";
            string manus = "";
            //MANU SEARCH
            List<int> selectedIDs = new List<int>();
            for (int i = 0; i < manuID.Length; i++)
            {
                if (manuSelect[i]) selectedIDs.Add(manuID[i]);
            }

            foreach (int id in selectedIDs)
            {
                manus += id.ToString() + ", ";
            }
            if(manus.Length >1) manus = manus.Remove(manus.Length - 2);
            sql = sql.Replace("@manus", manus);
            //OTHER CONDITIONS
            if (!(styleSymbol == null || styleSymbol.Equals("")))
            {
                end += " AND";
                end += " [style]='" + styleSymbol.ToLower()+"'";
            }

            if (fullSus != null)
            {
                end += " AND";
                end += " [fs]=" + ((bool)fullSus ? "1" : "0");
            }
            sql += end;
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, con))
            {
                adapter.Fill(table);
            }
            return table;
        }

        public DataTable GetAllBikes()
        {
            string sql = @"SELECT [B].[name] as [bike_name], [M].[name] as [manu_name], [style], [fs], [img_name], [url] 
FROM [Bikes] AS [B]
JOIN [Manus] AS [M] ON [B].[manu]=[M].[manu_id] ORDER BY [M].[name] ASC, [bike_name] ASC";
            DataTable table = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, con))
            {
                adapter.Fill(table);
            }
            return table;
        }

        public DataTable GetAllManus()
        {
            string sql = "SELECT [manu_id], [name] FROM [Manus]";
            DataTable table = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, con))
            {
                adapter.Fill(table);
            }
            return table;
        }

        public void Dispose()
        {
            con.Dispose();
        }
    }
}