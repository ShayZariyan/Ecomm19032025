using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecomm19032025.AdminManage
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<BLL.Users> lst = BLL.Users.GetAll();
                RptUsers.DataSource = lst; // מקשרת את רשימת המשתמשים לריפיטר
                RptUsers.DataBind();       // ממלאת את הריפיטר
            }

        }
    }
}