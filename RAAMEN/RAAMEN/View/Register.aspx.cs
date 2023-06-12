using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RAAMEN.Controller;

namespace RAAMEN.View
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void register_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string email = emailTextBox.Text;
            string gender = genderDropDownList.SelectedValue.ToString();
            string password = passwordTextBox.Text;
            string confirmPassword = confirmPasswordTextBox.Text;
            string role = userRoleDropDownList.SelectedValue.ToString();

            string message = RegisterController.checkRegister(username, email, gender, password, confirmPassword, role);
            errorMessage.Text = message;
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Login.aspx");
        }
    }
}