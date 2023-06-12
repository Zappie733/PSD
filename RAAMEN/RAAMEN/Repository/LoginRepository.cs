using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.UI.WebControls;
using RAAMEN.Model;

namespace RAAMEN.Repository
{
    public class LoginRepository
    {
        static DatabaseRaamenEntities1 db = DatabaseSingleton.getInstance();

        public static string getUser(string username, string password)
        {
            string message = "";
            User user = (from x in db.Users 
                         where x.Username == username && x.Password == password 
                         select x).FirstOrDefault();

            if (user == null)
            {
                message = "No User Found!";
            }
            else
            {
                if(user.RoleId == 1)
                {
                    message = "admin";
                }
                else if (user.RoleId == 2)
                {
                    message = "staff";
                }
                else if(user.RoleId == 3)
                {
                    message = "customer";
                }
            }

            return message;
        }
    }
}