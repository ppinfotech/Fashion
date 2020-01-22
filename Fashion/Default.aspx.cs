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
                fillMain();
            }
        }

        private void fillMain()
        {
            DataSet ds = new DataSet();
            clsDesign objDesign = new clsDesign();
            objDesign.Action = "TOP6";
            ds = objDesign.fnDesign();
            ViewState["dt"] = ds.Tables[0];
            string htm = string.Empty;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                htm += "<div class='col-md-4 '><a href='Lending.aspx?val=" + ds.Tables[0].Rows[i]["DesignId"].ToString() + "'><img class='img-thumbnail' src='/Design/" + ds.Tables[0].Rows[i]["ImagePath"].ToString() + "'><br><center><p style='font-weight:bold;'>" + ds.Tables[0].Rows[i]["DesignName"].ToString() + "</center></p></a></div>";
            }
            divMain.InnerHtml = htm;
        }
    }
}