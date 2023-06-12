using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAAMEN.Model;

namespace RAAMEN.Repository
{
    public class DatabaseSingleton
    {
        static DatabaseRaamenEntities1 db = null;

        private DatabaseSingleton() { }

        public static DatabaseRaamenEntities1 getInstance() 
        { 
            if(db == null)
            {
                db = new DatabaseRaamenEntities1();
            }
            return db;
        }
    }
}