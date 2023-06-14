using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Model;

namespace RAAMEN.Repository
{
    public class RegisterRepository
    {
        static DatabaseRaamenEntities1 db = DatabaseSingleton.getInstance();
        public static List<string> getAllUsername()
        {
            List<string> listUser = (from u in db.Users
                                   select u.Username).ToList();

            return listUser;
        }
        public static void insertUser(User newUser)
        {
            db.Users.Add(newUser);  
            db.SaveChanges();   
        }
    }
}