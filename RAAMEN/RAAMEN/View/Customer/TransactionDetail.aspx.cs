using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RAAMEN.Repository;
using RAAMEN.Model;

namespace RAAMEN.View.Customer
{
    public partial class TransactionDetail : System.Web.UI.Page
    {
        public List<Detail> listDetail = new List<Detail>();
        public int orderId;
        public int totalPrice;
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["orderId"];
            if(id != null)
            {
                orderId = Int32.Parse(id);
            }

            listDetail = OrderRepository.getDetailOrderById(orderId);
            totalPrice = OrderRepository.getDetailOrderTotalPriceById(orderId);
        }
        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Transaction.aspx");
        }
    }
}