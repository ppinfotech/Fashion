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
    public partial class Category : System.Web.UI.Page
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
                clsCategory objCategory = new clsCategory();
                DataSet ds = new DataSet();
                objCategory.Action = "SELECT";
                ds = objCategory.fnCategory();
                gvCategory.DataSource = ds;
                gvCategory.DataBind();
                ViewState["dt"] = ds.Tables[0];

            }
            catch (Exception ex)
            { }
        }

        private void clear()
        {
            lblId.Text = "";

            txtCategoryName.Text = "";
            txtDescription.Text = "";

            btnSubmit.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
        }

        private void Parameters(string Action, int CategoryId)
        {
            try
            {
                if (txtCategoryName.Text != "")
                {
                    clsCategory objCategory = new clsCategory();
                    DataSet ds = new DataSet();
                    objCategory.Action = Action;
                    objCategory.CategoryId = CategoryId;
                    objCategory.CategoryName = txtCategoryName.Text;
                    objCategory.Description = txtDescription.Text;

                    ds = objCategory.fnCategory();
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

        protected void gvCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "S")
            {
                DataView dv = new DataView();
                dv = ((DataTable)ViewState["dt"]).DefaultView;
                dv.RowFilter = "CategoryId = " + Convert.ToInt32(e.CommandArgument);
                DataTable dt = new DataTable();
                dt = dv.ToTable();

                lblId.Text = e.CommandArgument.ToString();
                txtCategoryName.Text = dt.Rows[0]["CategoryName"].ToString();
                txtDescription.Text = dt.Rows[0]["Description"].ToString();


                btnSubmit.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
            }
        }

        protected void gvCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCategory.PageIndex = e.NewPageIndex;
            gvCategory.DataSource = (DataTable)ViewState["dt"];
            gvCategory.DataBind();
        }

        protected void gvCategory_Sorting(object sender, GridViewSortEventArgs e)
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
            gvCategory.DataSource = sortedView;
            gvCategory.DataBind();
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