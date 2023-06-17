using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RAAMEN.Controller;

namespace RAAMEN.View.Admin
{
    public partial class InsertRamen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string meat = meatDropDownList.SelectedValue;
            string broth = brothTextBox.Text;
            string price = PriceTextBox.Text;


            string message = RamenController.checkInsert(name, meat, broth, price);
            errorMessage.Text = message;
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./ManageRamen.aspx");
        }
    }
}