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
        public static void insertUser(User newUser)
        {
            db.Users.Add(newUser);  
            db.SaveChanges();   
        }
    }
}