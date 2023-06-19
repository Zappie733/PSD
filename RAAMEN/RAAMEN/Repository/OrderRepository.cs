using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Model;


namespace RAAMEN.Repository
{
    public class OrderRepository
    {
        static DatabaseRaamenEntities1 db = DatabaseSingleton.getInstance();
        public static List<Header> getListOrderByStatus(bool status)
        {
            List<Header> listOrder = new List<Header>();
            listOrder = (from o in db.Headers
                         where o.Status == status
                         select o).ToList();

            return listOrder;
        }

        public static List<Header> getListOrderOfCustomer(int id, bool status)
        {
            List<Header> listOrder = new List<Header>();
            listOrder = (from o in db.Headers
                         where o.Status == status && o.User.Id == id
                         select o).ToList();

            return listOrder;
        }

        public static List<Detail> getDetailOrderById(int id)
        {
            List<Detail> listDetailOrder = new List<Detail>();
            listDetailOrder = (from d in db.Details
                               where d.HeaderId == id
                               select d).ToList();

            return listDetailOrder;
        }

        public static int getDetailOrderTotalPriceById(int id)
        {
            int totalPice = 0;
            List<Detail> listDetailOrder = new List<Detail>();
            listDetailOrder = (from d in db.Details
                               where d.HeaderId == id
                               select d).ToList();
            
            foreach(Detail detail in listDetailOrder)
            {
                int subtotal = (int)(Int32.Parse(detail.Ramen.Price) * detail.Quantity);
                totalPice += subtotal;
            }

            return totalPice;
        }

        public static void handleOrderById(string id, int handlerId)
        {
            if(id != null)
            {
                int orderId = Int32.Parse(id);

                Header order = new Header();
                order = (from o in db.Headers
                         where o.Id == orderId
                         select o).FirstOrDefault();

                order.Status = true;
                order.StaffId = handlerId;
                order.Date = DateTime.Now;
            }
            
            db.SaveChanges();
        }

        public static List<Cart> getListCustomerCart(int id)
        {
            List<Cart> listCart = (from c in db.Carts
                             where c.CustomerId == id
                             select c).ToList();
            return listCart;
        }

        public static void insertToCart(int id ,List<string> ramenId, List<string> quantity)
        {
            for(int i = 0; i < ramenId.Count(); i++)
            {
                Cart c = new Cart();
                c.CustomerId = id;
                c.RamenId = Int32.Parse(ramenId[i]);
                c.Quantity = Int32.Parse(quantity[i]);
                c.CreatedDate = DateTime.Now;

                db.Carts.Add(c);
            }

            db.SaveChanges();
        }

        public static void deleteCartById(string id)
        {
            int cartId = Int32.Parse(id);
            Cart cart = new Cart();
            cart = (from c in db.Carts
                    where c.Id == cartId
                    select c).FirstOrDefault();
            if(cart != null)
            {
                db.Carts.Remove(cart);
            }
            db.SaveChanges();
        }

        public static void deleteCustomerCartById(int customerId)
        {
            List<Cart> cart = new List<Cart>();
            cart = (from c in db.Carts
                    where c.CustomerId == customerId
                    select c).ToList();
            
            if (cart.Count > 0)
            {
                db.Carts.RemoveRange(cart);
            }
            db.SaveChanges();
        }

        public static void createOrder(int customerId)
        {
            Header order = new Header();
            order.CustomerId = customerId;
            order.Date = DateTime.Now;
            order.Status = false;
            db.Headers.Add(order);

            List<Cart> customerCart = getListCustomerCart(customerId);

            for(int i = 0; i<customerCart.Count(); i++)
            {
                Detail detailOrder = new Detail();
                detailOrder.HeaderId = order.Id;
                detailOrder.RamenId = customerCart[i].RamenId;
                detailOrder.Quantity = customerCart[i].Quantity;
                db.Details.Add(detailOrder);
            }

            deleteCustomerCartById(customerId);

            db.SaveChanges();
        }
    }
}