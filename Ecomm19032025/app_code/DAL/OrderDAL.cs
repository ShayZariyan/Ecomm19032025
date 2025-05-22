using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using DATA;

namespace DAL
{
    public class OrderDAL
    {
        public static Order GetByID(int oid)
        {
            DbContext db = new DbContext();
            string Sql = $"SELECT * FROM T_Order WHERE Oid = {oid}";

            DataTable dt = db.Execute(Sql);
            Order tmp = null;

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                tmp = new Order()
                {
                    Oid = Convert.ToInt32(row["Oid"]),
                    Uid = Convert.ToInt32(row["Uid"]),
                    OrderDate = Convert.ToDateTime(row["OrderDate"]),
                    TotalAmount = Convert.ToSingle(row["TotalAmount"]),
                    Status = row["Status"].ToString()
                };
            }

            db.Close();
            return tmp;
        }

        public static List<Order> GetAll()
        {
            DbContext db = new DbContext();
            string Sql = "SELECT * FROM T_Order";
            DataTable dt = db.Execute(Sql);
            List<Order> orders = new List<Order>();

            foreach (DataRow row in dt.Rows)
            {
                Order tmp = new Order()
                {
                    Oid = Convert.ToInt32(row["Oid"]),
                    Uid = Convert.ToInt32(row["Uid"]),
                    OrderDate = Convert.ToDateTime(row["OrderDate"]),
                    TotalAmount = Convert.ToSingle(row["TotalAmount"]),
                    Status = row["Status"].ToString()
                };
                orders.Add(tmp);
            }

            db.Close();
            return orders;
        }

        public static void Save(Order o)
        {
            DbContext db = new DbContext();
            string Sql;

            if (o.Oid == -1)
            {
                Sql = $"INSERT INTO T_Order (Uid, OrderDate, TotalAmount, Status) " +
                      $"VALUES ({o.Uid}, '{o.OrderDate:yyyy-MM-dd HH:mm:ss}', {o.TotalAmount}, N'{o.Status}')";
            }
            else
            {
                Sql = $"UPDATE T_Order SET " +
                      $"Uid = {o.Uid}, " +
                      $"OrderDate = '{o.OrderDate:yyyy-MM-dd HH:mm:ss}', " +
                      $"TotalAmount = {o.TotalAmount}, " +
                      $"Status = N'{o.Status}' " +
                      $"WHERE Oid = {o.Oid}";
            }

            int retval = db.ExecuteNonQuery(Sql);

            if (o.Oid == -1)
            {
                Sql = $"SELECT MAX(Oid) FROM T_Order WHERE Uid = {o.Uid}";
                o.Oid = (int)db.ExecuteScalar(Sql);
            }

            db.Close();
        }

        public static List<Order> GetOrdersByUser(int uid)
        {
            DbContext db = new DbContext();
            string Sql = $"SELECT * FROM T_Order WHERE Uid = {uid} ORDER BY OrderDate DESC";
            DataTable dt = db.Execute(Sql);
            List<Order> orders = new List<Order>();

            foreach (DataRow row in dt.Rows)
            {
                Order tmp = new Order()
                {
                    Oid = Convert.ToInt32(row["Oid"]),
                    Uid = Convert.ToInt32(row["Uid"]),
                    OrderDate = Convert.ToDateTime(row["OrderDate"]),
                    TotalAmount = Convert.ToSingle(row["TotalAmount"]),
                    Status = row["Status"].ToString()
                };
                orders.Add(tmp);
            }

            db.Close();
            return orders;
        }

        public static int DeleteByID(int oid)
        {
            DbContext db = new DbContext();
            string Sql = $"DELETE FROM T_Order WHERE Oid = {oid}";
            int retval = db.ExecuteNonQuery(Sql);
            db.Close();
            return retval;
        }
    }
}
