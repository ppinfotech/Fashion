using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Fashion.ClassFiles;

namespace Fashion
{
    public partial class Color : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = new DataSet();
                clsColor objColor = new clsColor();
                objColor.Action = "SELECT";
                ds = objColor.fnColor();
                string htm = string.Empty;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    htm += "<div class='col-md-1'><p style='background-color:" + ds.Tables[0].Rows[i]["ColorHex"].ToString() + " !important; height:15px;'><p></div>";
                }
                divColorChart.InnerHtml = htm;
            }
        }
    }
}