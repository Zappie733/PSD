using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RAAMEN.Model;
using RAAMEN.Repository;

namespace RAAMEN.View.Staff
{
    public partial class Staff : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["staff_session"] == null)
            {
                Response.Redirect("../Login.aspx");
            }

            string username = ((User)Session["staff_session"]).Username;
            string password = ((User)Session["staff_session"]).Password;

            User user = UserRepository.getUser(username, password);
            UserRoleLabel.Text = "Role: " + UserRepository.getUserRole(user);
        }

        protected void LogoutLinkButton_Click(object sender, EventArgs e)
        {
            //delete session
            Session.Clear();

            //delete cookie
            HttpCookie cookie = Request.Cookies.Get("user_cookie");
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }

            Response.Redirect("../Login.aspx");
        }
    }
}