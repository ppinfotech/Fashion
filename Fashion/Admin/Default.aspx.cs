using Fashion.ClassFiles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fashion.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text != "" && txtPassword.Text != "")
            {
                DataSet ds = new DataSet();
                clsAdmin objAdmin = new clsAdmin();
                objAdmin.Action = "LOGIN";
                objAdmin.UserName = txtUserName.Text;
                objAdmin.Password = txtPassword.Text;
                ds = objAdmin.fnAdmin();
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Session["AdminName"] = ds.Tables[0].Rows[0]["UserName"].ToString();
                    Session["IsSuperAdmin"] = ds.Tables[0].Rows[0]["IsSuperAdmin"].ToString();
                    Session["AdminId"] = ds.Tables[0].Rows[0]["AdminId"].ToString();
                    Response.Redirect("Panel/Dashboard.aspx", false);
                }
                else
                {
                    //invalid user
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert('Invalid username or password')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert('Enter username and password')", true);
            }
            //Response.Redirect("Panel/Dashboard.aspx", false);
        }
    }
}