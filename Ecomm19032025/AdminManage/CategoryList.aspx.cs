using BLL;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecomm19032025.AdminManage
{
    public partial class CategoryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                List<Category> lst = Category.GetAll();      // שליפת כל הקטגוריות
                RptCategories.DataSource = lst;              // קישור לריפיטר
                RptCategories.DataBind();                    // הצגת הנתונים
            }
        }
    }
}
