using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RAAMEN.Model;
using RAAMEN.Repository;
using RAAMEN.Handler;

namespace RAAMEN.View.Customer
{
    public partial class OrderRamen : System.Web.UI.Page
    {
        public List<Ramen> ramens = new List<Ramen>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ramens = RamenRepository.getAllRamen();
        }

        protected void orderButton_Click(object sender, EventArgs e)
        {

        }
    }
}