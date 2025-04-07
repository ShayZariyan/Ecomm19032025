using BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class OrderDAL
    {
        private static readonly string ConnStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True";

        public static Order GetByID(int oid)
        {
            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {
                Conn.Open();
                string Sql = "SELECT * FROM T.Order WHERE Oid = @Oid";
                SqlCommand cmd = new SqlCommand(Sql, Conn);
                cmd.Parameters.AddWithValue("@Oid", oid);
                SqlDataReader Dr = cmd.ExecuteReader();
                Order tmp = null;
                if (Dr.Read())
                {
                    tmp = new Order()
                    {
                        Oid = (int)Dr["Oid"],
                        Uid = (int)Dr["Uid"],
                        OrderDate = Convert.ToDateTime(Dr["OrderDate"]),
                        TotalAmount = Convert.ToSingle(Dr["TotalAmount"]),
                        Status = Dr["Status"].ToString()
                    };
                }
                return tmp;
            }
        }

        public static List<Order> GetAll()
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {
                Conn.Open();
                string Sql = "SELECT * FROM T.Order";
                SqlCommand cmd = new SqlCommand(Sql, Conn);
                SqlDataReader Dr = cmd.ExecuteReader();

                while (Dr.Read())
                {
                    orders.Add(new Order()
                    {
                        Oid = (int)Dr["Oid"],
                        Uid = (int)Dr["Uid"],
                        OrderDate = Convert.ToDateTime(Dr["OrderDate"]),
                        TotalAmount = Convert.ToSingle(Dr["TotalAmount"]),
                        Status = Dr["Status"].ToString()
                    });
                }
            }

            return orders;
        }

        public static void Save(Order o)
        {
            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {
                Conn.Open();
                string Sql = "INSERT INTO T.Order (Uid, OrderDate, TotalAmount, Status) VALUES (@Uid, @OrderDate, @TotalAmount, @Status)";
                SqlCommand cmd = new SqlCommand(Sql, Conn);
                cmd.Parameters.AddWithValue("@Uid", o.Uid);
                cmd.Parameters.AddWithValue("@OrderDate", o.OrderDate);
                cmd.Parameters.AddWithValue("@TotalAmount", o.TotalAmount);
                cmd.Parameters.AddWithValue("@Status", o.Status);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(Order o)
        {
            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {
                Conn.Open();
                string Sql = "UPDATE T.Order SET Uid = @Uid, OrderDate = @OrderDate, TotalAmount = @TotalAmount, Status = @Status WHERE Oid = @Oid";
                SqlCommand cmd = new SqlCommand(Sql, Conn);
                cmd.Parameters.AddWithValue("@Uid", o.Uid);
                cmd.Parameters.AddWithValue("@OrderDate", o.OrderDate);
                cmd.Parameters.AddWithValue("@TotalAmount", o.TotalAmount);
                cmd.Parameters.AddWithValue("@Status", o.Status);
                cmd.Parameters.AddWithValue("@Oid", o.Oid);
                cmd.ExecuteNonQuery();
            }
        }

        public static int DeleteByID(int oid)
        {
            string ConnStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True";
            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {
                Conn.Open();
                string Sql = "DELETE FROM T.Order WHERE Oid = @Oid";
                SqlCommand cmd = new SqlCommand(Sql, Conn);
                cmd.Parameters.AddWithValue("@Oid", oid);
                int rowsAffected = cmd.ExecuteNonQuery();
                Conn.Close();

                if (rowsAffected > 0)
                    return 1;
                else
                    return 0;
            }
        }


        public static List<Order> GetOrdersByUser(int uid)
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {
                Conn.Open();
                string Sql = "SELECT * FROM T.Order WHERE Uid = @Uid";
                SqlCommand cmd = new SqlCommand(Sql, Conn);
                cmd.Parameters.AddWithValue("@Uid", uid);
                SqlDataReader Dr = cmd.ExecuteReader();

                while (Dr.Read())
                {
                    orders.Add(new Order()
                    {
                        Oid = (int)Dr["Oid"],
                        Uid = (int)Dr["Uid"],
                        OrderDate = Convert.ToDateTime(Dr["OrderDate"]),
                        TotalAmount = Convert.ToSingle(Dr["TotalAmount"]),
                        Status = Dr["Status"].ToString()
                    });
                }
            }

            return orders;
        }
    }
}
