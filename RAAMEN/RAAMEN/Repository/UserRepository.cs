using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using RAAMEN.Model;

namespace RAAMEN.Repository
{
    public class UserRepository
    {
        static DatabaseRaamenEntities1 db = DatabaseSingleton.getInstance();

        public static User getUser(string username, string password)
        {
            User user = (from u in db.Users 
                         where u.Username == username && u.Password == password 
                         select u).FirstOrDefault();

            return user;
        }

        public static string getUserRole(User user) 
        {
            string role = (from r in db.Roles
                           where r.Id == user.RoleId
                           select r.Name).FirstOrDefault().ToString();

            return role;
        }
    }
}