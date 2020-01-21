using Fashion.ClassFiles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fashion.Admin.Panel
{
    public partial class Fabric : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    fillGrid();
                }
                else
                {
                    divAlert.Visible = false;
                }
            }
            catch
            { }
        }

        private void fillGrid()
        {
            try
            {
                clsFabric objFabric = new clsFabric();
                DataSet ds = new DataSet();
                objFabric.Action = "SELECT";
                ds = objFabric.fnFabric();
                gvFabric.DataSource = ds;
                gvFabric.DataBind();
                ViewState["dt"] = ds.Tables[0];

                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryId";
                ddlCategory.DataSource = ds.Tables[1];
                ddlCategory.DataBind();
            }
            catch (Exception ex)
            { }
        }

        private void clear()
        {
            lblId.Text = "";

            txtDescription.Text = "";
            txtFabricName.Text = "";
            ddlCategory.ClearSelection();

            btnSubmit.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
        }

        private void Parameters(string Action, int FabricId)
        {
            try
            {
                if (txtFabricName.Text != "")
                {
                    clsFabric objFabric = new clsFabric();
                    DataSet ds = new DataSet();
                    objFabric.Action = Action;
                    objFabric.FabricId = FabricId;
                    objFabric.FabricName = txtFabricName.Text;
                    objFabric.Description = txtDescription.Text;
                    objFabric.CategoryId = Convert.ToInt32(ddlCategory.SelectedItem.Value);
                    objFabric.ImagePath = "";
                    if (FileUpload1.HasFile)
                    {
                        var _with1 = HttpContext.Current;
                        string strPath = _with1.Server.MapPath("/Fabric/");
                        HttpPostedFile postedFile = FileUpload1.PostedFile;
                        string filename = postedFile.FileName;
                        string fileExt1 = System.IO.Path.GetExtension(filename).Replace(".", "");
                        fileExt1 = System.IO.Path.GetExtension(filename).Replace(".", "");
                        filename = filename.Replace("." + fileExt1, "");
                        filename = filename + "1" + string.Format("{0:MMddyyyyhhmmssfffffftt}", DateTime.Now) + "." + fileExt1.ToString();
                        postedFile.SaveAs(strPath + filename);

                        objFabric.ImagePath = filename;
                    }


                    ds = objFabric.fnFabric();
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        divAlert.Visible = true;
                        divAlert.InnerHtml = ds.Tables[0].Rows[0]["MSG"].ToString();
                    }
                    else
                    {
                        divAlert.Visible = true;
                        divAlert.InnerHtml = "Something went wrong";
                    }
                    fillGrid();
                    clear();
                }
                else
                {
                    divAlert.Visible = true;
                    divAlert.InnerHtml = "Enter all required fileds";
                }
            }
            catch
            {
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Parameters("INSERT", 0);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Parameters("UPDATE", Convert.ToInt32(lblId.Text));
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Parameters("DELETE", Convert.ToInt32(lblId.Text));
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
            divAlert.Visible = false;
        }

        protected void gvFabric_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "S")
            {
                DataView dv = new DataView();
                dv = ((DataTable)ViewState["dt"]).DefaultView;
                dv.RowFilter = "FabricId = " + Convert.ToInt32(e.CommandArgument);
                DataTable dt = new DataTable();
                dt = dv.ToTable();

                lblId.Text = e.CommandArgument.ToString();

                txtDescription.Text = dt.Rows[0]["Description"].ToString();
                txtFabricName.Text = dt.Rows[0]["FabricName"].ToString();
                ddlCategory.ClearSelection();
                ddlCategory.Items.FindByValue(dt.Rows[0]["CategoryId"].ToString()).Selected = true;


                btnSubmit.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
            }
        }

        protected void gvFabric_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFabric.PageIndex = e.NewPageIndex;
            gvFabric.DataSource = (DataTable)ViewState["dt"];
            gvFabric.DataBind();
        }

        protected void gvFabric_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortingDirection = string.Empty;
            if (direction == SortDirection.Ascending)
            {
                direction = SortDirection.Descending;
                sortingDirection = "Desc";
            }
            else
            {
                direction = SortDirection.Ascending;
                sortingDirection = "Asc";
            }
            DataView sortedView = new DataView();
            sortedView = ((DataTable)ViewState["dt"]).DefaultView;
            sortedView.Sort = e.SortExpression + " " + sortingDirection;
            gvFabric.DataSource = sortedView;
            gvFabric.DataBind();
        }
        public SortDirection direction
        {
            get
            {
                if (ViewState["directionState"] == null)
                {
                    ViewState["directionState"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["directionState"];
            }
            set
            {
                ViewState["directionState"] = value;
            }
        }
    }
}