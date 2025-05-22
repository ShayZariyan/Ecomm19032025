using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace Ecomm19032025.AdminManage
{
    public partial class OrderDetails : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string oid = Request["Oid"];
                if (!string.IsNullOrEmpty(oid))
                {
                    int orderId = int.Parse(oid);
                    Order o = Order.GetByID(orderId);
                    if (o != null)
                    {
                        LblOid.Text = o.Oid.ToString();
                        LblUid.Text = o.Uid.ToString();
                        LblTotalAmount.Text = o.TotalAmount.ToString("C");
                        LblStatus.Text = o.Status;
                        LblOrderDate.Text = o.OrderDate.ToString("dd/MM/yyyy HH:mm");
                    }
                    else
                    {
                        Response.Write("<div class='alert alert-danger'>ההזמנה לא נמצאה</div>");
                    }
                }
            }
        }
    }
}
