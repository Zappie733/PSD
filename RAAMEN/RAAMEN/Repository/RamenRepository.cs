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

        public static string insertRamen(Ramen newramen)
        {
            db.Ramen1.Add(newramen);
            db.SaveChanges();

            return newramen.Name;
        }

        public static List<string> getAllRamenName()
        {
            List<string> listRamenName = (from r in db.Ramen1
                                     select r.Name).ToList();

            return listRamenName;
        }

        public static Ramen getRamenById(int id)
        {
            Ramen ramen = (from r in db.Ramen1
                           where r.Id == id
                           select r).FirstOrDefault();

            return ramen;
        }

        public static Ramen getRamenByName(string name)
        {
            Ramen ramen = (from r in db.Ramen1
                           where r.Name == name
                           select r).FirstOrDefault();

            return ramen;
        }

        public static List<string> updateRamen(string name, string meat, string broth, string price, string curName)
        {
            List<string> messages = new List<string>();
            Ramen ramen = getRamenByName(curName);

            if (!ramen.Name.Equals(name))
            {
                ramen.Name = name;
                messages.Add("name");
            }
            if (!ramen.Meat.Name.Equals(meat))
            {
                int meatId = 0;
                if (meat == "chiken")
                {
                    meatId = 1;
                }
                else if (meat == "pork")
                {
                    meatId = 2;
                }
                else if (meat == "beef")
                {
                    meatId = 3;
                }

                if(meatId != 0)
                {
                    ramen.MeatId = meatId;
                    messages.Add("meat");
                }
            }
            if (!ramen.Broth.Equals(broth))
            {
                ramen.Broth = broth;
                messages.Add("broth");
            }
            if (!ramen.Price.Equals(price))
            {
                ramen.Price = price;
                messages.Add("price");
            }

            db.SaveChanges();

            return messages;
        }
    }
}