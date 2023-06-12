using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Model;

namespace RAAMEN.Factory
{
    public class UserFactory
    {
        public static User createUser(string username, string email, string gender, string password, string role)
        {
            User newUser = new User();
            newUser.Username = username;
            newUser.Email = email;
            newUser.Gender = gender;
            newUser.Password = password;
            if (role.Equals("staff"))
            {
                newUser.RoleId = 2;
            }
            else if (role.Equals("member"))
            {
                newUser.RoleId = 3;
            }

            return newUser;
        }
        public static User createUserForSession(string username, string password)
        {
            User user = new User();
            user.Username = username;
            user.Password = password;
            return user;
        }
    }
}