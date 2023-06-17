using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Handler;
using System.Text.RegularExpressions;
using RAAMEN.Repository;

namespace RAAMEN.Controller
{
    public class RamenController
    {
        public static string checkNameForInsert(string name)
        {
            string message = "";
            List<string> listRamenName = RamenRepository.getAllRamenName();
            if (name.Equals(""))
            {
                message = "username cannot be empty";
            }
            else if (!name.Contains("Ramen"))
            {
                message = "name must contains \'Ramen\'";
            }
            else if (listRamenName.Contains(name))
            {
                message = "ramen name had been taken";
            }
            return message;
        }

        public static string checkNameForUpdate(string name, string curName)
        {
            string message = "";
            List<string> listRamenName = RamenRepository.getAllRamenName();
            if (name.Equals(""))
            {
                message = "username cannot be empty";
            }
            else if (!name.Contains("Ramen"))
            {
                message = "name must contains \'Ramen\'";
            }
            else if (!name.Equals(curName))
            {
                if (listRamenName.Contains(name))
                {
                    message = "ramen name had been taken";
                }
            }
            return message;
        }

        public static string checkMeat(string meat)
        {
            string message = "";
            if (meat.Equals(""))
            {
                message = "meat must be selected";
            }
            return message;
        }

        public static string checkBroth(string broth)
        {
            string message = "";
            if (broth.Equals(""))
            {
                message = "broth cannot be empty";
            }
            return message;
        }

        public static string checkPrice(string price)
        {
            string message = "";
            if (price.Equals(""))
            {
                message = "Price cannot be empty";
            }
            else if (!Regex.IsMatch(price, @"^[0-9]+$"))
            {
                message = "Price must be numbers";
            }
            else if (Int32.Parse(price) < 3000)
            {
                message = "Price must be at least 3000";
            }
            return message;
        }

        public static string checkInsert(string name, string meat, string broth, string price)
        {
            string message = checkNameForInsert(name);
            if (message.Equals(""))
            {
                message = checkMeat(meat);
                if (message.Equals(""))
                {
                    message = checkBroth(broth);
                    if (message.Equals(""))
                    {
                        message = checkPrice(price);
                        if (message.Equals(""))
                        {
                            message = RamenHandler.insert(name, meat, broth, price);
                        }
                    }
                }
            }

            return message;
        }

        public static string checkUpdate(string name, string meat, string broth, string price, string curName)
        {
            string message = checkNameForUpdate(name, curName);
            if (message.Equals(""))
            {
                message = checkMeat(meat);
                if (message.Equals(""))
                {
                    message = checkBroth(broth);
                    if (message.Equals(""))
                    {
                        message = checkPrice(price);
                        if (message.Equals(""))
                        {
                            message = RamenHandler.update(name, meat, broth, price, curName);
                        }
                    }
                }
            }

            return message;
        }
    }
}