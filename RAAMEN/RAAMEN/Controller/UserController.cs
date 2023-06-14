using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using RAAMEN.Handler;
using RAAMEN.Repository;


namespace RAAMEN.Controller
{
    public class UserController
    {
        public static string checkUsername(string username, string curUsername)
        {
            string message = "";
            List<string> listUsername = UserRepository.getAllUsername();

            if (username.Equals(""))
            {
                message = "username cannot be empty";
            }
            else if (username.Length < 5 || username.Length > 15)
            {
                message = "username length mush between 5 and 15";
            }
            else if (!Regex.IsMatch(username, @"^[a-zA-Z\s]+$"))
            {
                message = "username must contain only alphabet characters and spaces";
            }
            else if (!username.Equals(curUsername))
            {
                if (listUsername.Contains(username))
                {
                    message = "username had been taken";
                }
            }

            return message;
        }
        public static string checkEmail(string email)
        {
            string message = "";
            if (email.Equals(""))
            {
                message = "email cannot be empty";
            }
            else if (!email.EndsWith(".com"))
            {
                message = "email must end with .com";
            }
            return message;
        }

        public static string checkGender(string gender)
        {
            string message = "";

            if (gender.Equals(""))
            {
                message = "gender Must be chosen";
            }
            return message;
        }

        public static string checkPassword(string password, string curPassword)
        {
            string message = "";
            if (password.Equals(""))
            {
                message = "password cannot be empty";
            }
            else if (!password.Equals(curPassword))
            {
                message = "Use your password to confirm update";
            }
            return message;
        }

        public static string checkUpdate(string username, string email, string gender, string password, string curUsername, string curPassword)
        {
            string message = checkUsername(username, curUsername);

            if (message.Equals(""))
            {
                message = checkEmail(email);

                if (message.Equals(""))
                {
                    message = checkGender(gender);

                    if (message.Equals(""))
                    {
                        message = checkPassword(password, curPassword);

                        if (message.Equals(""))
                        {
                            message = UserHandler.update(username, email, gender, password, curUsername);
                        }
                    }
                }
            }

            return message;
        }
    }
}