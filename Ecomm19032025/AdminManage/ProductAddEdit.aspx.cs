using BLL; // שימוש בשכבת הלוגיקה העסקית
using DAL;
using System; // שימוש בפונקציות כלליות של .NET
using System.Collections.Generic; // לעבודה עם רשימות
using System.IO;
using System.Linq; // לעבודה עם LINQ
using System.Web; // לעבודה עם Web Forms
using System.Web.UI; // לעבודה עם עמודי ASP.NET
using System.Web.UI.WebControls; // לעבודה עם פקדי Web (כמו DropDownList)

namespace Ecomm19032025.AdminManage // מרחב שמות של אזור הניהול באתר
{
    public partial class ProductAddEdit : System.Web.UI.Page // מחלקה שמייצגת את העמוד ProductAddEdit
    {
        protected void Page_Load(object sender, EventArgs e) // מתבצע בכל טעינת עמוד
        {
            if (!IsPostBack) // התנאי מתבצע רק בטעינה הראשונה ולא אחרי לחיצה על כפתור
            {
                string Pid = Request["Pid"] + ""; // מקבל את מזהה המוצר מהשורת כתובת אם יש
                Product p = null; // מגדיר משתנה שיחזיק את המוצר

                if (!string.IsNullOrEmpty(Pid)) // אם יש מזהה מוצר בכתובת
                {
                    p = Product.GetbyID(int.Parse(Pid)); // מביא את המוצר לפי מזהה
                }

                // קודם כל ממלא את רשימת הקטגוריות
                List<Category> LstCat = Category.GetAll(); // מביא את כל הקטגוריות מהמסד
                DDLCategory.DataSource = LstCat; // קובע את המקור נתונים של ה-DropDown
                DDLCategory.DataValueField = "Cid"; // קובע את השדה שישמש כערך
                DDLCategory.DataTextField = "Cname"; // קובע את השדה שיוצג למשתמש
                DDLCategory.DataBind(); // טוען את הנתונים לרשימה

                if (p != null) // אם נמצא מוצר (לא חדש)
                {
                    TxtPname.Text = p.Pname; // ממלא את שם המוצר
                    TxtPdesc.Text = p.Pdesc; // ממלא את תיאור המוצר
                    TxtPrice.Text = p.Price + ""; // ממלא את המחיר
                    TxtPicname.Text = p.Picname; // ממלא את שם הקובץ של התמונה
                    HidPid.Value = p.Pid + ""; // שם את מזהה המוצר בשדה מוסתר

                    // אם הקטגוריה קיימת ברשימה, קובעת אותה כבחירה
                    if (DDLCategory.Items.FindByValue(p.Cid + "") != null)
                    {
                        DDLCategory.SelectedValue = p.Cid + ""; // בוחר את הקטגוריה של המוצר
                    }
                }
                else
                {
                    HidPid.Value = "-1"; // אם לא נמצא מוצר – נחשב כמוצר חדש
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string Picname = "";

            if (UplPic.HasFile) // אם נבחר קובץ נעלה אותו ונשמור בשם חדש
            {
                // Get random 8-character string (you must have GlobFunc.GetRandStr)
                string FileName = GlobFunc.GetRandStr(8);

                // Get extension from uploaded file
                int ind = UplPic.FileName.LastIndexOf('.');
                string Ext = UplPic.FileName.Substring(ind); // e.g. ".jpg"

                // Combine to form full image filename
                Picname = FileName + Ext;

                // Save the file to server path
                string folderPath = Server.MapPath("/uploads/prods/img/");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                UplPic.SaveAs(Path.Combine(folderPath, Picname));

                // Optional: store filename in a hidden field or textbox
                TxtPicname.Text = Picname;
            }
            Product Tmp = new Product() // יצירת אובייקט מוצר עם הערכים שמוזנים בטופס בעמוד
            {
                Pid = int.Parse(HidPid.Value),
                Picname = TxtPicname.Text,
                Pdesc = TxtPdesc.Text,
                Price = float.Parse(TxtPrice.Text),
                Pname = TxtPname.Text,
                Status = int.Parse(DDLStatus.SelectedValue)
            };

            Tmp.Save(); // הפעלת השיטה ששומרת על הנתונים לבסיס הנתונים
            Response.Redirect("ProductList.aspx"); // מעבר לעמוד הצגת כלל המוצרים
        }

    }
}
