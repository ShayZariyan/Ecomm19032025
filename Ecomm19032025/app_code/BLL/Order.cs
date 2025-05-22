using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class Order
    {
        public int Oid { get; set; } = -1;                     // New orders start at -1
        public int Uid { get; set; }                           // User placing the order
        public float TotalAmount { get; set; }                 // Total price of order
        public string Status { get; set; }                     // e.g. 'חדש', 'שולם'
        public DateTime OrderDate { get; set; } = DateTime.Now; // Default to now

        public static Order GetByID(int oid)
        {
            return OrderDAL.GetByID(oid);
        }

        public static List<Order> GetAll()
        {
            return OrderDAL.GetAll();
        }

        public static List<Order> GetOrdersByUser(int uid)
        {
            return OrderDAL.GetOrdersByUser(uid);
        }

        public int Save()
        {
            OrderDAL.Save(this);
            return Oid;
        }

        public static int DeleteByID(int oid)
        {
            return OrderDAL.DeleteByID(oid);
        }
    }
}
