using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Repository;

namespace RAAMEN.Handler
{
    public class UserHandler
    {
        public static string update(string username, string email, string gender, string password, string curUsername) 
        {
            List<string> message = new List<string>();
            message = UserRepository.updateUser(username, email, gender, password, curUsername);
            bool flag = false;

            string finalMessage = "Your account(";
            if (message.Contains("username"))
            {
                finalMessage = finalMessage + "username";
                flag = true;
            }
            if (message.Contains("email"))
            {
                if(flag == true)
                {
                    finalMessage = finalMessage + ",email";
                }
                else
                {
                    finalMessage = finalMessage + "email";
                    flag = true;
                }
            }
            if (message.Contains("gender"))
            {
                if(flag == true)
                {
                    finalMessage = finalMessage + ",gender";
                }
                else
                {
                    finalMessage = finalMessage + "gender";
                }
            }

            finalMessage = finalMessage + ") has been successfuly updated";

            if(!message.Contains("username") && !message.Contains("email") && !message.Contains("gender"))
            {
                finalMessage = "Nothing to update";
            } 

            return finalMessage;
        }
    }
}