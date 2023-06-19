using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RAAMEN.Repository;
using RAAMEN.Model;
using RAAMEN.Handler;

namespace RAAMEN.View.Staff
{
    public partial class ManageRamen : System.Web.UI.Page
    {
        //public List<Ramen> listRamen { get; set; }
        public List<Ramen> listRamen = new List<Ramen>();
        private string message;
        protected void Page_Load(object sender, EventArgs e)
        {
            listRamen = RamenRepository.getAllRamen();
            string ramenId = Request.QueryString["ramenId"];
            string status = Request.QueryString["deleteStatusLabel"];
            if (ramenId != null)
            {
                message = RamenHandler.statusDeleteRamen(int.Parse(ramenId));
                Response.Redirect("./ManageRamen.aspx?deleteStatusLabel=" + message);
            }
            if(status != null)
            {
                StatusLabel.Text = status;
            }
        }

        protected void InsertButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./InsertRamen.aspx");
        }
    }
}