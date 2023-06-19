using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RAAMEN.Model;
using RAAMEN.Handler;
using RAAMEN.Repository;

namespace RAAMEN.View.Customer
{
    public partial class Transaction : System.Web.UI.Page
    {
        public List<Header> listHandledOrder = new List<Header>();
        public List<List<Detail>> listDetailOrder = new List<List<Detail>>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer_session"] == null)
            {
                Response.Redirect("../Login.aspx");
            }

            string username = ((User)Session["customer_session"]).Username;
            string password = ((User)Session["customer_session"]).Password;

            listHandledOrder = OrderHandler.customerHistoryOrder(username, password);

            foreach (Header order in listHandledOrder)
            {
                List<Detail> detailOrder = new List<Detail>();
                detailOrder = OrderRepository.getDetailOrderById(order.Id);

                listDetailOrder.Add(detailOrder);
            }
        }
    }
}