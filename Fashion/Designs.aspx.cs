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
    public partial class Designs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillDesigns();
            }
        }

        private string fillImg(DataTable dt)
        {
            string htm = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                htm += "<div class='col-md-4'><a href='Lending.aspx?val=" + dt.Rows[i]["DesignId"].ToString() + "'><img class='img-thumbnail' src='/Design/" + dt.Rows[i]["ImagePath"].ToString() + "'><br><center><h4>" + dt.Rows[i]["DesignName"].ToString() + "</h4></center></a></div>";
            }
            return htm;
        }

        private void fillDesigns()
        {
            DataSet ds = new DataSet();
            clsDesign objDesign = new clsDesign();
            objDesign.Action = "SELECT";
            ds = objDesign.fnDesign();
            ViewState["dt"] = ds.Tables[0];

            divDesigns.InnerHtml = fillImg(ds.Tables[0]);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                DataView dv = new DataView();
                dv = ((DataTable)ViewState["dt"]).DefaultView;
                dv.RowFilter = "DesignName = '" + Convert.ToString(txtSearch.Text) + "'";
                DataTable dt = new DataTable();

                divDesigns.InnerHtml = fillImg(dv.ToTable());
            }
        }
    }
}