using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Model;

namespace RAAMEN.Factory
{
    public class RamenFactory
    {
        public static Ramen createRamen(string name, string meat, string broth, string price)
        {
            Ramen ramen = new Ramen();
            ramen.Name = name;
            if (meat.Equals("chiken"))
            {
                ramen.MeatId = 1;
            }
            else if (meat.Equals("pork")){
                ramen.MeatId = 2;
            }
            else if (meat.Equals("beef"))
            {
                ramen.MeatId = 3;
            }
            ramen.Broth = broth;
            ramen.Price = price;

            return ramen;
        }
    }
}