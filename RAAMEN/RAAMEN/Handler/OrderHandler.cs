using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Repository;
using RAAMEN.Model;

namespace RAAMEN.Handler
{
    public class OrderHandler
    {
        public static string handlerOrder(string orderId, string username, string password)
        {
            User user = UserRepository.getUser(username, password);
           
            OrderRepository.handleOrderById(orderId, user.Id);

            return "OrderId(" + orderId + ") has been handled";
        }

        public static List<Header> ongoingOrder (string username, string password)
        {
            User user = UserRepository.getUser(username, password);

            List<Header> ongoingOrder = OrderRepository.getListOrderOfCustomer(user.Id, false);

            return ongoingOrder;
        }

        public static List<Header> customerHistoryOrder(string username, string password)
        {
            User user = UserRepository.getUser(username, password);

            List<Header> historyOrder = OrderRepository.getListOrderOfCustomer(user.Id, true);

            return historyOrder;
        }

        public static List<Cart> customerCart(string username, string password)
        {
            User user = UserRepository.getUser(username, password);

            List<Cart> listCart = OrderRepository.getListCustomerCart(user.Id);

            return listCart;
        }

        public static string addToCart(string username, string password, List<string>ramenId, List<string> quantity)
        {
            User user = UserRepository.getUser(username, password);

            OrderRepository.insertToCart(user.Id, ramenId, quantity);

            return "all your order has been added to cart, go check your cart";
        }

        public static string deleteCartItem(string id, string ramen, string quantity)
        {
            OrderRepository.deleteCartById(id);
            return "CartId:" + id + " (" + ramen + ", " + quantity + ") has been succesfully removed from your cart";
        }
        public static string deleteAllCartItem(string username, string password)
        {
            User user = UserRepository.getUser(username, password);

            OrderRepository.deleteCustomerCartById(user.Id);
            return "All items in your cart has been succesfully removed from your cart";
        }

        public static string makeOrder(string username, string password)
        {
            User user = UserRepository.getUser(username, password);

            OrderRepository.createOrder(user.Id);

            return "All items in your cart has been succesfully created as an order, check your ongoing order at home page";
        }
    }
}