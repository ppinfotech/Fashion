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
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text != "" && txtConfirmPassword.Text != "")
            {
                if (txtNewPassword.Text == txtConfirmPassword.Text)
                {
                    DataSet ds = new DataSet();
                    clsAdmin objAdmin = new clsAdmin();
                    objAdmin.Action = "CHANGEPWD";
                    objAdmin.AdminId = Convert.ToInt32(Session["AdminId"]);
                    objAdmin.Password = txtConfirmPassword.Text;
                    ds = objAdmin.fnAdmin();
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        divAlert.Visible = true;
                        divAlert.InnerHtml = ds.Tables[0].Rows[0]["MSG"].ToString();
                    }
                }
                else
                {
                    divAlert.Visible = true;
                    divAlert.InnerHtml = "Password Mismatched";
                }
            }
            else
            {
                divAlert.Visible = true;
                divAlert.InnerHtml = "Enter all fields";
            }
        }
    }
}