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
        
        public static List<Detail> getDetailOrderById(int id)
        {
            List<Detail> listDetailOrder = new List<Detail>();
            listDetailOrder = (from d in db.Details
                               where d.HeaderId == id
                               select d).ToList();

            return listDetailOrder;
        }
    }
}