using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RAAMEN.Model;
using RAAMEN.Repository;
using RAAMEN.Handler;

namespace RAAMEN.View.Admin
{
    public partial class OrderQueue : System.Web.UI.Page
    {
        public List<Header> listOrderUnhandled = new List<Header>();
        public List<Header> listOrderHandled = new List<Header>();
        public List<List<Detail>> listDetailOrderUnhandled = new List<List<Detail>>();
        public List<List<Detail>> listDetailOrderHandled = new List<List<Detail>>();
        private string message;

        protected void Page_Load(object sender, EventArgs e)
        {
            listOrderUnhandled = OrderRepository.getListOrderByStatus(false);
            listOrderHandled = OrderRepository.getListOrderByStatus(true);

            foreach (Header order in listOrderUnhandled)
            {
                List<Detail> detailOrder = new List<Detail>();
                detailOrder = OrderRepository.getDetailOrderById(order.Id);

                listDetailOrderUnhandled.Add(detailOrder);
            }

            foreach (Header order in listOrderHandled)
            {
                List<Detail> detailOrder = new List<Detail>();
                detailOrder = OrderRepository.getDetailOrderById(order.Id);

                listDetailOrderHandled.Add(detailOrder);
            }

            if (Session["admin_session"] == null)
            {
                Response.Redirect("../Login.aspx");
            }

            string username = ((User)Session["admin_session"]).Username;
            string password = ((User)Session["admin_session"]).Password;

            string orderId = Request.QueryString["orderId"];
            string status = Request.QueryString["orderStatus"];

            if (orderId != null)
            {
                message = OrderHandler.handlerOrder(orderId, username, password);
                Response.Redirect("./OrderQueue.aspx?orderStatus=" + message);
            }
            if (status != null)
            {
                StatusLabel.Text = status;
            }
        }
    }
}