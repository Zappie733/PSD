using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using RAAMEN.Handler;

namespace RAAMEN.Controller
{
    public class RegisterController
    {
        public static string checkUsername(string username)
        {
            string message = "";
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

        public static string checkPassword(string password)
        {
            string message = "";
            if (password.Equals(""))
            {
                message = "password cannot be empty";
            }
            return message;
        }

        public static string checkConfirmPassword(string password, string confirmPassword)
        {
            string message = "";
            if (confirmPassword.Equals(""))
            {
                message = "confirm password cannot be empty";
            }
            else if (!confirmPassword.Equals(password)){
                message = "confirm password must be equal with password";
            }
            return message;
        }

        public static string checkRole(string role)
        {
            string message = "";
            if (role.Equals(""))
            {
                message = "role cannot be empty";
            }
            return message;
        }

        public static string checkRegister(string username, string email, string gender, string password, string confirmPassword, string role) 
        {
            string message = checkUsername(username);

            if(message.Equals(""))
            {
                message = checkEmail(email);
                if (message.Equals(""))
                {
                    message = checkGender(gender);
                    if (message.Equals(""))
                    {
                        message = checkPassword(password);
                        if (message.Equals(""))
                        {
                            message = checkConfirmPassword(password, confirmPassword);
                            if (message.Equals("")) 
                            {
                                message = checkRole(role);
                                if (message.Equals(""))
                                {
                                    message = RegisterHandler.register(username, email, gender, password, role);
                                }
                            }
                        }
                    }
                }
            }

            return message;
        } 
    }
}