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
    public partial class Design : System.Web.UI.Page
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
                clsDesign objDesign = new clsDesign();
                DataSet ds = new DataSet();
                objDesign.Action = "SELECT";
                ds = objDesign.fnDesign();
                gvDesign.DataSource = ds;
                gvDesign.DataBind();
                ViewState["dt"] = ds.Tables[0];

            }
            catch (Exception ex)
            { }
        }

        private void clear()
        {
            lblId.Text = "";

            txtDescription.Text = "";
            txtDesignName.Text = "";

            btnSubmit.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
        }

        private void Parameters(string Action, int DesignId)
        {
            try
            {
                if (txtDesignName.Text != "")
                {
                    clsDesign objDesign = new clsDesign();
                    DataSet ds = new DataSet();
                    objDesign.Action = Action;
                    objDesign.DesignId = DesignId;
                    objDesign.DesignName = txtDesignName.Text;
                    objDesign.Description = txtDescription.Text;
                    objDesign.ImagePath = "";
                    if (FileUpload1.HasFile)
                    {
                        var _with1 = HttpContext.Current;
                        string strPath = _with1.Server.MapPath("/Design/");
                        HttpPostedFile postedFile = FileUpload1.PostedFile;
                        string filename = postedFile.FileName;
                        string fileExt1 = System.IO.Path.GetExtension(filename).Replace(".", "");
                        fileExt1 = System.IO.Path.GetExtension(filename).Replace(".", "");
                        filename = filename.Replace("." + fileExt1, "");
                        filename = filename + "1" + string.Format("{0:MMddyyyyhhmmssfffffftt}", DateTime.Now) + "." + fileExt1.ToString();
                        postedFile.SaveAs(strPath + filename);

                        objDesign.ImagePath = filename;
                    }


                    ds = objDesign.fnDesign();
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

        protected void gvDesign_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "S")
            {
                DataView dv = new DataView();
                dv = ((DataTable)ViewState["dt"]).DefaultView;
                dv.RowFilter = "DesignId = " + Convert.ToInt32(e.CommandArgument);
                DataTable dt = new DataTable();
                dt = dv.ToTable();

                lblId.Text = e.CommandArgument.ToString();

                txtDescription.Text = dt.Rows[0]["Description"].ToString();
                txtDesignName.Text = dt.Rows[0]["DesignName"].ToString();


                btnSubmit.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
            }
        }

        protected void gvDesign_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDesign.PageIndex = e.NewPageIndex;
            gvDesign.DataSource = (DataTable)ViewState["dt"];
            gvDesign.DataBind();
        }

        protected void gvDesign_Sorting(object sender, GridViewSortEventArgs e)
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
            gvDesign.DataSource = sortedView;
            gvDesign.DataBind();
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