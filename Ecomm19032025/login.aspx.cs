using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace Ecomm19032025
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnlgn_Click(object sender, EventArgs e)
        {
            string Email=TxtEmail.Text;
            string Pass = TextPass.Text;
            Users us=Users.CheckLogin(Email, Pass);
            if (us != null)
            {
                Session["Login"]=us;
                Response.Redirect("/AdminManage");
            }
            else { }
        }
        
    }
}