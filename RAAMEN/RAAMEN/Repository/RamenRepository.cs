using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Model;

namespace RAAMEN.Repository
{
    public class RamenRepository
    {
        static DatabaseRaamenEntities1 db = DatabaseSingleton.getInstance();

        public static List<Ramen> getAllRamen()
        {
            List<Ramen> listRamen = new List<Ramen>();

            listRamen = (from r in db.Ramen1 select r).ToList();

            return listRamen;
        }

        public static string deleteRamen(int id)
        {
            Ramen ramen = (from r in db.Ramen1
                           where r.Id == id
                           select r).FirstOrDefault();

            if(ramen == null)
            {
                return null;
            }
            
            db.Ramen1.Remove(ramen);
            db.SaveChanges();
            return ramen.Name;
        }
    }
}