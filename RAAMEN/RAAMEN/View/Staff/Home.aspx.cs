using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RAAMEN.Model;
using RAAMEN.Repository;

namespace RAAMEN.View.Staff
{
    public partial class Home : System.Web.UI.Page
    {
        public List<User> listCustomer = new List<User>();
        protected void Page_Load(object sender, EventArgs e)
        {  
            listCustomer = UserRepository.getAllUserByRoleId(3);
        }
    }
}