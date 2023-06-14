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

        public static List<User> getAllUserByRoleId(int roleId)
        {
            List<User> listUser = (from u in db.Users
                               where u.RoleId == roleId
                               select u).ToList();

            return listUser;
        }

        public static List<string> getAllUsername()
        {
            List<string> listUser = (from u in db.Users
                                     select u.Username).ToList();

            return listUser;
        }

        public static List<string> updateUser(string username, string email, string gender, string password, string curUsername)
        {
            List<string> messages = new List<string>();

            User user = getUser(curUsername, password);

            if(!username.Equals(user.Username))
            {
                user.Username = username;
                messages.Add("username");
            }
            if (!email.Equals(user.Email))
            {
                user.Email = email;
                messages.Add("email");
            }
            if (!gender.Equals(user.Gender))
            {
                user.Gender = gender;
                messages.Add("gender");
            }

            db.SaveChanges();

            return messages;
        }
    }
}