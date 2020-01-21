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
                htm += "<div class='col-md-4'><p style='background-color:" + ds.Tables[0].Rows[i]["ColorHex"].ToString() + "; height:15px;'><p></div>";
            }
            divColorChart.InnerHtml = htm;
        }
    }
}