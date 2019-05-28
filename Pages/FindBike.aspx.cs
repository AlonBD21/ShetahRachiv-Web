using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code;
using System.Data;

public partial class FindBike : System.Web.UI.Page
{
    DataTable bikes;
    DataTable manus;
    string[] styleSymbols;
    string styleSymbol;
    bool?[] fss;
    bool? fs;
    bool[] manuSelect;
    int[] manuID;
    int resultRows;

    protected void Page_Load(object sender, EventArgs e)
    {
        styleSymbols = new string[] { "", "dj", "tr", "am", "dh" };
        fss = new bool?[] { null, false, true };
        if (!IsPostBack)
        {
            ddlStyle.SelectedIndex = 0;
            ddlFS.SelectedIndex = 0;
            using (CatalogMananager cm = new CatalogMananager())
            {
                manus = cm.GetAllManus();
            }

            DataRow dr;
            for (int i = 0; i < manus.Rows.Count; i++)
            {
                dr = manus.Rows[i];
                ListItem newLi = new ListItem(dr["name"].ToString(), dr["manu_id"].ToString(), true);
                newLi.Selected = true;
                cblManu.Items.Add(newLi);
            }
        }
    }

    protected void Send_Click(object sender, EventArgs e)
    {
        mainErr.Text = "";
        //INPUT CHECK
        bool manuInputCheck = false;
        //MANUS
        manuID = new int[cblManu.Items.Count];
        manuSelect = new bool[cblManu.Items.Count];
        for (int i = 0; i < cblManu.Items.Count; i++)
        {
            manuID[i] = int.Parse(cblManu.Items[i].Value);
            manuSelect[i] = cblManu.Items[i].Selected;
            if (manuSelect[i]) manuInputCheck = true;
        }
        if (!manuInputCheck)
        {
            mainErr.Text = "יש לבחור לפחות יצרן אחד";
            return;
        }
        //OTHER PARAMS
        styleSymbol = styleSymbols[ddlStyle.SelectedIndex];
        fs = fss[ddlFS.SelectedIndex];
        //EXCECUTION
        using (CatalogMananager cm = new CatalogMananager())
        {
            bikes = cm.ChooseBikes(styleSymbol, manuID, manuSelect, fs);
        }
        lv.DataSource = bikes;
        lv.DataBind();

        resultRows = bikes.Rows.Count;
        resCount.Visible = true;
        if (resultRows == 0)
        {
            resCount.Text = "מצטערים לא נמצאו אופניים במאגר.";
        }
        else
        {
            resCount.Text = "נמצאו " + resultRows + " תוצאות לחיפוש";
        }

    }
}