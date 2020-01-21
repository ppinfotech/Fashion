using Fashion.ClassFiles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fashion
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                color();
            }
        }
        private void color()
        {
            DataSet ds = new DataSet();
            clsColor objColor = new clsColor();
            objColor.Action = "SELECT";
            ds = objColor.fnColor();
            string htm = string.Empty;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                htm += "<div class='col-md-2 col-sm-4 col-lg-2 col-xs-4'><p onclick='fillPallet(this)' style='background-color:" + ds.Tables[0].Rows[i]["ColorHex"].ToString() + "; color:" + ds.Tables[0].Rows[i]["ColorHex"].ToString() + ";'>" + ds.Tables[0].Rows[i]["ColorHex"].ToString() + "<p></div>";
            }
            divColorChart.InnerHtml = htm;
        }
    }
}