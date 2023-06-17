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
    public partial class OrderQueue : System.Web.UI.Page
    {
        public List<Header> listOrderUnhandled = new List<Header>();
        public List<Header> listOrderHandled = new List<Header>();
        public List<List<Detail>> listDetailOrderUnhandled = new List<List<Detail>>();
        public List<List<Detail>> listDetailOrderHandled = new List<List<Detail>>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            listOrderUnhandled = OrderRepository.getListOrderByStatus(false);
            listOrderHandled = OrderRepository.getListOrderByStatus(true);

            foreach(Header order in listOrderUnhandled)
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
        }

        protected void handleButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}