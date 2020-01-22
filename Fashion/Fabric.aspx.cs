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
    public partial class Fabric : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                clsDesign objDesign = new clsDesign();
                DataSet ds = new DataSet();
                objDesign.Action = "ISELECT";
                objDesign.DesignId = 0;
                ds = objDesign.fnDesign();
                //divMain.InnerHtml = "<div id='divBG'><img src='/Design/" + ds.Tables[0].Rows[0]["ImagePath"].ToString() + "' id='imgMain' style='background-image: url(f3.jpg); background-repeat: repeat; width: 100%; background-size: 200px;' /></div>";

                ddlFabric.DataTextField = "CategoryName";
                ddlFabric.DataValueField = "CategoryId";
                ddlFabric.DataSource = ds.Tables[1];
                ddlFabric.DataBind();

                ViewState["dtFabric"] = ds.Tables[2];

                ddlFabric_SelectedIndexChanged(null, null);



                //color();
            }                //string htm = string.Empty;
                             //for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                             //{
                             //    htm += "<div class='col-md-2 col-sm-4 col-lg-2 col-xs-4'><p onclick='fillPallet(this)' style='font-size:1px; height:10px; background-color:" + ds.Tables[3].Rows[i]["ColorHex"].ToString() + "; color:" + ds.Tables[3].Rows[i]["ColorHex"].ToString() + ";'>" + ds.Tables[3].Rows[i]["ColorHex"].ToString() + "<p></div>";
                             //}
                             //divColorChart.InnerHtml = htm;

        }
        protected void ddlFabric_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView();
            dv = ((DataTable)ViewState["dtFabric"]).DefaultView;
            dv.RowFilter = "CategoryId = " + Convert.ToInt32(ddlFabric.SelectedItem.Value);
            DataTable dt = new DataTable();
            dt = dv.ToTable();
            string htm = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                htm += "<div class='col-md-4' style='padding-bottom:10px;'><img src='/Fabric/" + dt.Rows[i]["ImagePath"].ToString() + "' style='width: 100%' onclick='fillBG(this)' /></div>";
            }
            divFabric.InnerHtml = htm;
        }
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
