using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using App_Code;
public partial class Catalog : System.Web.UI.Page
{
    DataTable bikes;
    protected void Page_Load(object sender, EventArgs e)
    {
        using (CatalogMananager cm = new CatalogMananager())
        {
            bikes = cm.GetAllBikes();
        }
        lv.DataSource = bikes;
        lv.DataBind();
    }
}