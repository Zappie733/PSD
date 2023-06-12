using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using RAAMEN.Model;
using RAAMEN.Repository;
using RAAMEN.Factory;

namespace RAAMEN.Handler
{
    public class RegisterHandler
    {
        public static string register(string username, string email, string gender, string password, string role)
        {
            User newUser = UserFactory.createUser(username, email, gender, password, role);

            RegisterRepository.insertUser(newUser);

            return "Your account has been successfully created";
        }
    }
}