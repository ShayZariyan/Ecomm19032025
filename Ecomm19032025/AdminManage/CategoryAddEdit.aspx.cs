using BLL; // שימוש בשכבת הלוגיקה העסקית
using DAL;
using System; // שימוש בפונקציות כלליות של .NET
using System.Collections.Generic; // לעבודה עם רשימות
using System.Linq; // לעבודה עם LINQ
using System.Web; // לעבודה עם Web Forms
using System.Web.UI; // לעבודה עם עמודי ASP.NET
using System.Web.UI.WebControls; // לעבודה עם פקדי Web (כמו TextBox)

namespace Ecomm19032025.AdminManage
{
    public partial class CategoryAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string cid = Request["Cid"] + "";
                Category c = null;

                if (!string.IsNullOrEmpty(cid))
                {
                    c = Category.GetByID(int.Parse(cid));
                }

                if (c != null)
                {
                    TxtCname.Text = c.Cname;
                    TxtCdesc.Text = c.Cdesc;
                    HidCid.Value = c.Cid.ToString();
                }
                else
                {
                    HidCid.Value = "-1";
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            Category tmp = new Category()
            {
                Cid = int.Parse(HidCid.Value),
                Cname = TxtCname.Text,
                Cdesc = TxtCdesc.Text
            };

            tmp.Save();
            Response.Redirect("CategoryList.aspx");
        }
    }
}
