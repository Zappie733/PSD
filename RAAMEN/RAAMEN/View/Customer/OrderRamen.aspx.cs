using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using RAAMEN.Model;
using RAAMEN.Repository;
using RAAMEN.Handler;

namespace RAAMEN.View.Customer
{
    public partial class OrderRamen : System.Web.UI.Page
    {
        public List<Ramen> listRamen = new List<Ramen>();
        public List<Cart> listCart = new List<Cart>();
        public static List<string> listRamenId;
        public static List<string> listQuantity;
        static OrderRamen()
        {
            listRamenId = new List<string>();
            listQuantity = new List<string>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer_session"] == null)
            {
                Response.Redirect("../Login.aspx");
            }

            string username = ((User)Session["customer_session"]).Username;
            string password = ((User)Session["customer_session"]).Password;


            string cartId = Request.QueryString["cartId"];
            string ramen = Request.QueryString["ramen"];
            string quantity = Request.QueryString["quantity"];
            if (cartId != null && ramen != null && quantity != null)
            {
                string messsage = OrderHandler.deleteCartItem(cartId, ramen, quantity);
                cartStatus.Text = messsage;
            }

            listRamen = RamenRepository.getAllRamen();
            listCart = OrderHandler.customerCart(username, password);
        }

        [System.Web.Services.WebMethod]
        public static string AddToCart(string ramenId, string quantity)
        {
            if(ramenId != null && quantity != null)
            {
                listRamenId.Add(ramenId);
                listQuantity.Add(quantity);
            }

            string message = "Successfuly added to cart(ramenId:" + ramenId + " quantity:" + quantity + ")";

            return message;
        }

        protected void AddToCartButton_Click(object sender, EventArgs e)
        {
            if (Session["customer_session"] == null)
            {
                Response.Redirect("../Login.aspx");
            }

            string username = ((User)Session["customer_session"]).Username;
            string password = ((User)Session["customer_session"]).Password;
            string message = "";
            message = OrderHandler.addToCart(username, password, listRamenId, listQuantity);
            statusLabel.Text = message;

            listRamenId.Clear();
            listQuantity.Clear();
            Response.Redirect("OrderRamen.aspx");
        }

        protected void clearButton_Click(object sender, EventArgs e)
        {
            if (Session["customer_session"] == null)
            {
                Response.Redirect("../Login.aspx");
            }

            string username = ((User)Session["customer_session"]).Username;
            string password = ((User)Session["customer_session"]).Password;
            string message = "";
            message = OrderHandler.deleteAllCartItem(username, password);
            cartStatus.Text = message;
        }

        protected void orderButton_Click(object sender, EventArgs e)
        {
            if (Session["customer_session"] == null)
            {
                Response.Redirect("../Login.aspx");
            }

            string username = ((User)Session["customer_session"]).Username;
            string password = ((User)Session["customer_session"]).Password;
            string message = "";
            message = OrderHandler.makeOrder(username, password);
            cartStatus.Text = message;
        }
    }
}