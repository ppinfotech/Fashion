using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fashion
{
    public partial class Fabric : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    fillFabricks();
            //}
        }

        //private string fillImg(DataTable dt)
        //{
        //    string htm = string.Empty;
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        htm += "<div class='col-md-4'><a href='Lending.aspx?val=" + dt.Rows[i]["FabricId"].ToString() + "'><img class='img-thumbnail' src='/Design/" + dt.Rows[i]["ImagePath"].ToString() + "'><br><center><h4>" + dt.Rows[0]["DesignName"].ToString() + "</h4></center></a></div>";
        //    }
        //    return htm;
        //}
    }
}