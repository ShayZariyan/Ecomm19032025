using BLL; // שימוש בשכבת הלוגיקה העסקית
using DAL;
using System; // שימוש בפונקציות כלליות של .NET
using System.Collections.Generic; // לעבודה עם רשימות
using System.Linq; // לעבודה עם LINQ
using System.Web; // לעבודה עם Web Forms
using System.Web.UI; // לעבודה עם עמודי ASP.NET
using System.Web.UI.WebControls; // לעבודה עם פקדי Web (כמו DropDownList)

namespace Ecomm19032025.AdminManage // מרחב שמות של אזור הניהול באתר
{
    public partial class UserAddEdit : System.Web.UI.Page // מחלקה שמייצגת את העמוד UserAddEdit
    {
        protected void Page_Load(object sender, EventArgs e) // מתבצע בכל טעינת עמוד
        {
            if (!IsPostBack) // התנאי מתבצע רק בטעינה הראשונה ולא אחרי לחיצה על כפתור
            {
                string Uid = Request["Uid"] + ""; // מקבל את מזהה המשתמש מהשורת כתובת אם יש
                Users u = null; // מגדיר משתנה שיחזיק את המשתמש

                if (!string.IsNullOrEmpty(Uid))
                {
                    u = Users.GetByID(int.Parse(Uid)); // מביא את המשתמש לפי מזהה
                }

                if (u != null) // אם נמצא משתמש (עריכה)
                {
                    TxtFname.Text = u.Fname;
                    TxtEmail.Text = u.Email;
                    TxtPass.Text = u.Pass;
                    TxtAddress.Text = u.Address;
                    TxtPhone.Text = u.Phone;
                    HidUid.Value = u.Uid + "";
                }
                else
                {
                    HidUid.Value = "-1"; // משתמש חדש
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            Users Tmp = new Users()
            {
                Uid = int.Parse(HidUid.Value),
                Fname = TxtFname.Text,
                Email = TxtEmail.Text,
                Pass = TxtPass.Text,
                Address = TxtAddress.Text,
                Phone = TxtPhone.Text
            };

            Tmp.Save(); // שמירה או עדכון המשתמש
            Response.Redirect("UserList.aspx"); // מעבר לעמוד רשימת המשתמשים
        }
    }
}
