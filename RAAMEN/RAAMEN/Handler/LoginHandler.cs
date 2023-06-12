using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Repository;

namespace RAAMEN.Handler
{
    public class LoginHandler
    {
        public static string login(string username, string password)
        {
            string message = "";
            message = LoginRepository.getUser(username, password);
            
            return message;
        }
    }
}