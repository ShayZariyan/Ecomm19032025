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
                
        }
        protected void CheckLgn(object sender, EventArgs e)
        {
            List<Users> users = new List<Users>();
            Users tmp;
            tmp = new Users()
            {
                Uid = 1,
                Email = "shayzariyan1@gmail.com",
                Fname = "Shay Zariyan",
                Address = "Gedera",
                Pass = "1234",
                Phone = "0527009423"
            };
            users.Add(tmp);
            tmp = new Users()
            {
                Uid = 2,
                Email = "shayza1@gmail.com",
                Fname = "Shy",
                Address = "Gedera",
                Pass = "1234",
                Phone = "0522009423"
            };
            users.Add(tmp);
            tmp = new Users()
            {
                Uid = 3,
                Email = "shay@gmail.com",
                Fname = "Shay",
                Address = "Gedera",
                Pass = "1234",
                Phone = "0527669423"
            };
            users.Add(tmp);

            for (int i = 0; i < users.Count; i++)
            {

                if (users[i].Email == txtuser.Text && users[i].Pass == txtpass.Text)
                {
                    Session["Login"] = users[i];
                    Response.Redirect("/AdminManage");
                }
                else
                {
                    LtlMsg.Text = "Error, Wrong User / Password.";
                }
            }
        }
    }
}