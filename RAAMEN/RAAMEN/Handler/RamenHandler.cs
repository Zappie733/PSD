using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Repository;

namespace RAAMEN.Handler
{
    public class RamenHandler
    {
        public static string statusDeleteRamen(int id)
        {
            string message;
            string delete = RamenRepository.deleteRamen(id);

            if(delete != null)
            {
                message = delete + " has been successfuly deleted";
            }
            else
            {
                message = "Delete ramen failed";
            }

            return message;
        }
    }
}