using BLL; // שימוש בשכבת הלוגיקה העסקית
using DAL;
using System; // שימוש בפונקציות כלליות של .NET
using System.Collections.Generic; // לעבודה עם רשימות
using System.Linq; // לעבודה עם LINQ
using System.Web; // לעבודה עם Web Forms
using System.Web.UI; // לעבודה עם עמודי ASP.NET
using System.Web.UI.WebControls; // לעבודה עם פקדי Web

namespace Ecomm19032025.AdminManage
{
    public partial class OrderAddEdit : Page // מחלקה שמייצגת את העמוד OrderAddEdit
    {
        protected void Page_Load(object sender, EventArgs e) // מתבצע בכל טעינת עמוד
        {
            if (!IsPostBack) // ריצה רק בטעינה ראשונית
            {
                string oid = Request["Oid"] + ""; // מזהה ההזמנה מה-QueryString
                Order order = null;

                if (!string.IsNullOrEmpty(oid))
                {
                    order = Order.GetByID(int.Parse(oid)); // טעינת הזמנה לפי מזהה
                }

                if (order != null) // עריכת הזמנה קיימת
                {
                    TxtUid.Text = order.Uid.ToString();
                    TxtTotal.Text = order.TotalAmount.ToString("0.00");
                    DDLStatus.SelectedValue = order.Status;
                    TxtDate.Text = order.OrderDate.ToString("yyyy-MM-dd HH:mm");
                    HidOid.Value = order.Oid.ToString();
                }
                else
                {
                    HidOid.Value = "-1"; // הזמנה חדשה
                    TxtDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            Order tmp = new Order()
            {
                Oid = int.Parse(HidOid.Value),
                Uid = int.Parse(TxtUid.Text),
                TotalAmount = float.Parse(TxtTotal.Text),
                Status = DDLStatus.SelectedValue,
                OrderDate = DateTime.Parse(TxtDate.Text)
            };

            tmp.Save(); // שמירה למסד הנתונים
            Response.Redirect("OrderList.aspx"); // מעבר חזרה לרשימת ההזמנות
        }
    }
}
