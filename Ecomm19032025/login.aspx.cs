using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecomm19032025
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnlgn_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == "banana" && txtpass.Text == "iambanana")
            {
                Response.Redirect("default.aspx");
            }
            else
            {
                Response.Redirect("Error.aspx");
            }
        }
    }
}