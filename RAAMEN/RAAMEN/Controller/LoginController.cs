using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using RAAMEN.Handler;

namespace RAAMEN.Controller
{
    public class LoginController
    {
        public static string checkUsername(string username)
        {
            string message = "";
            if (username.Equals(""))
            {
                message = "username cannot be empty";
            }
            return message;
        }

        public static string checkPassword(string password)
        {
            string message = "";
            if (password.Equals(""))
            {
                message = "password cannot be empty";
            }
            return message;
        }

        public static string checkLogin(string username, string password)
        {
            string message = checkUsername(username);
            if (message.Equals(""))
            {
                message = checkPassword(password);
                if (message.Equals(""))
                {
                    message = LoginHandler.login(username, password);
                }
            }

            return message;
        }
    }
}