using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Repository;
using RAAMEN.Model;
using RAAMEN.Factory;

namespace RAAMEN.Handler
{
    public class RamenHandler
    {
        public static string statusDeleteRamen(int id)
        {
            string message;
            string delete = RamenRepository.deleteRamen(id);

            if(delete != null)
            {
                message = delete + " has been successfuly deleted";
            }
            else
            {
                message = "Delete ramen failed";
            }

            return message;
        }

        public static string insert(string name, string meat, string broth, string price)
        {

            Ramen ramen = RamenFactory.createRamen(name, meat, broth, price);

            string ramenName = RamenRepository.insertRamen(ramen);

            return ramenName + " has been successfully inserted";

        }

        public static string update(string name, string meat, string broth, string price, string curName)
        {
            List<string> message = new List<string>();
            message = RamenRepository.updateRamen(name, meat, broth, price, curName);
            
            bool flag = false;

            string finalMessage = curName + " (";
            if (message.Contains("name"))
            {
                finalMessage = finalMessage + "name";
                flag = true;
            }
            if (message.Contains("meat"))
            {
                if (flag == true)
                {
                    finalMessage = finalMessage + ",meat";
                }
                else
                {
                    finalMessage = finalMessage + "meat";
                    flag = true;
                }
            }
            if (message.Contains("broth"))
            {
                if (flag == true)
                {
                    finalMessage = finalMessage + ",broth";
                }
                else
                {
                    finalMessage = finalMessage + "broth";
                    flag = true;
                }
            }
            if (message.Contains("price"))
            {
                if (flag == true)
                {
                    finalMessage = finalMessage + ",price";
                }
                else
                {
                    finalMessage = finalMessage + "price";
                }
            }

            finalMessage = finalMessage + ") has been successfuly updated";

            if (!message.Contains("name") && !message.Contains("meat") && !message.Contains("broth") && !message.Contains("price"))
            {
                finalMessage = "Nothing to update";
            }

            return finalMessage;
        }
    }
}