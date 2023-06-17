using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RAAMEN.Model;
using RAAMEN.Repository;
using RAAMEN.Controller;


namespace RAAMEN.View.Admin
{
    public partial class UpdateRamen : System.Web.UI.Page
    {
        public string CurName { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            string Id = Request.QueryString["ramenId"];

            if (Id == null)
            {
                Response.Redirect("./ManageRamen.aspx");
            }
            int ramenId = Int32.Parse(Id);

            Ramen ramen = RamenRepository.getRamenById(ramenId);

            if (!IsPostBack)
            {
                idTextBox.Text = ramen.Id.ToString();
                nameTextBox.Text = ramen.Name;
                meatDropDownList.SelectedValue = ramen.Meat.Name;
                brothTextBox.Text = ramen.Broth;
                priceTextBox.Text = ramen.Price;
            }

            CurName = ramen.Name;
        }

        protected void editButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Enabled = true;
            meatDropDownList.Enabled = true;
            brothTextBox.Enabled = true;
            priceTextBox.Enabled = true;
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string meat = meatDropDownList.SelectedValue;
            string broth = brothTextBox.Text;
            string price = priceTextBox.Text;

            string message = "";
            message = RamenController.checkUpdate(name, meat, broth, price, CurName);
            updateMessage.Text = message;

            if (message == "" || message.EndsWith("updated") || message.StartsWith("Nothing"))
            {
                nameTextBox.Enabled = false;
                meatDropDownList.Enabled = false;
                brothTextBox.Enabled = false;
                priceTextBox.Enabled = false;
            }
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./ManageRamen.aspx");
        }
    }
}