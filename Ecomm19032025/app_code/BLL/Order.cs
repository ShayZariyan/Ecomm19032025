using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class Order
    {
        public int Oid { get; set; }
        public int Uid { get; set; }
        public float TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }

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