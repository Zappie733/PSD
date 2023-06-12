using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RAAMEN.Controller;
using RAAMEN.Factory;
using RAAMEN.Model;

namespace RAAMEN.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(Session["admin_session"] != null)
            //{
            //    Response.Redirect("./Admin/Home.aspx");
            //}
            //else if(Session["staff_session"] != null)
            //{
            //    Response.Redirect("./Staff/Home.aspx");
            //}
            //else if(Session["customer_session"] != null)
            //{
            //    Response.Redirect("./Customer/Home.aspx");
            //}

            if (!IsPostBack)
            {
                if (Session["admin_session"] != null || Session["staff_session"] != null || Session["customer_session"] != null)
                {
                    Session.Clear();
                }

                //HttpCookie cookie = Request.Cookies["user_cookie"];
                HttpCookie cookie = Request.Cookies.Get("user_cookie");

                //jika user_cookie masih ada maka usernameTextBox dan passwordTextBox akan secara default terisi value username dan password yang ada di cookie, jika tidak ada cookie berarti value textboxnya tetap null.
                if (cookie != null)
                {
                    //usernameTextBox.Text = cookie.Values["username"];
                    usernameTextBox.Text = cookie.Values.Get("username");
                    passwordTextBox.Text = cookie.Values.Get("password");
                }
            }
        }

        protected void login_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            string message = LoginController.checkLogin(username, password);
            
            if(message != "admin" && message != "staff" && message != "customer")
            {
                errorMessage.Text = message;
            }
            else
            {
                //bikin cookie
                bool remember = rememberCheckBox.Checked;
                if(remember == true)
                {
                    HttpCookie cookie = new HttpCookie("user_cookie");
                    //cookie.Values["username"] = username;
                    cookie.Values.Add("username", username);
                    cookie.Values.Add("password", password);

                    cookie.Expires = DateTime.Now.AddMinutes(30);

                    Response.Cookies.Add(cookie);//nambahin cookie ke app
                }
                //else if(remember == false)
                //{

                //}

                //bikin session
                User user = UserFactory.createUserForSession(username, password);

                if (message == "admin")
                {
                    Session["admin_session"] = user;
                    Response.Redirect("./Admin/Home.aspx");
                }
                else if (message == "staff")
                {
                    Session["staff_session"] = user;
                    Response.Redirect("./Staff/Home.aspx");
                }
                else if (message == "customer")
                {
                    Session["customer_session"] = user;
                    Response.Redirect("./Customer/Home.aspx");
                }
                // ada 3 jenis session, gunanya agar masing2 role memiliki 1 jenis session khusus yang nantinya dapat digunakan untuk Authorization, jadi semisal user login as customer, berarti user tersebut hanya dapat mengakses halaman2 view yang berhubungan dengan customer saja. Jika user tersebut mencoba untuk memasuki halaman milik staff atau admin maka user tersebut akan didirect balik ke home page customer karena user tersebut tidak memiiki session staff ataupun session admin, yang user miliki adalah session customer.
            }
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Register.aspx");
        }

       
    }
}