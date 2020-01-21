using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fashion.Admin.Panel
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Request.Cookies["AdminName"] != null)
            {
                HttpCookie AdminName = Request.Cookies["AdminName"];
                Session["AdminName"] = AdminName.Value;
                HttpCookie IsSuperAdmin = Request.Cookies["IsSuperAdmin"];
                Session["IsSuperAdmin"] = IsSuperAdmin.Value;
                HttpCookie AdminId = Request.Cookies["AdminId"];
                Session["AdminId"] = AdminId.Value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["AdminName"] != null)
                    {
                        lblName.Text = Session["AdminName"].ToString();

                        //create cookies

                        lblAdminName.Text = Session["AdminName"].ToString();
                        HttpCookie AdminName = new HttpCookie("AdminName", Session["AdminName"].ToString());
                        AdminName.Expires.AddYears(50);
                        Response.Cookies.Add(AdminName);

                        lblIsSuperAdmin.Text = Session["IsSuperAdmin"].ToString();
                        HttpCookie IsSuperAdmin = new HttpCookie("IsSuperAdmin", Session["IsSuperAdmin"].ToString());
                        IsSuperAdmin.Expires.AddYears(50);
                        Response.Cookies.Add(IsSuperAdmin);

                        lblAdminId.Text = Session["AdminId"].ToString();
                        HttpCookie AdminId = new HttpCookie("AdminId", Session["AdminId"].ToString());
                        AdminId.Expires.AddYears(50);
                        Response.Cookies.Add(AdminId);

                        //page role
                        //admin
                    }
                    else
                    {
                        Response.Redirect("../Default.aspx", false);
                    }
                }
            }
            catch
            {
                Response.Redirect("../Default.aspx", false);
            }
        }
    }
}