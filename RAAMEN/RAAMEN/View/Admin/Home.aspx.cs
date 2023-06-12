using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RAAMEN.Model;
using RAAMEN.Repository;

namespace RAAMEN.View.Admin
{
    public partial class Home : System.Web.UI.Page
    {
        private List<User> listCustomer = new List<User>();
        private List<User> listStaff = new List<User>();
        public List<List<User>> listUser = new List<List<User>>();
        protected void Page_Load(object sender, EventArgs e)
        {
            listCustomer = UserRepository.getAllUserByRoleId(3);
            listUser.Add(listCustomer);
            listStaff = UserRepository.getAllUserByRoleId(2);
            listUser.Add(listStaff);
        }
    }
}