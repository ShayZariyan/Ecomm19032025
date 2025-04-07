using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace DAL
{
    public class ProductDAL
    {
        public static Product GetbyID(int pid)
        {
            string ConnStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True";
            SqlConnection Conn = new SqlConnection(ConnStr);
            Conn.Open();
            string Sql = $"SELECT * FROM T.Product Where Pid = {pid}";
            SqlCommand cmd = new SqlCommand(Sql, Conn);
            SqlDataReader Dr = cmd.ExecuteReader();
            Product tmp = null;
            if (Dr.Read() == true)
            {
                tmp = new Product()
                {
                    Pid = (int)Dr["Pid"],
                    Pname = Dr["Pname"].ToString(),
                    Price = (float)Dr["Price"],
                    Pdesc = Dr["Pdesc"].ToString(),
                    Cid = (int)Dr["Cid"],
                    Picname = (string)Dr["Picname"]
                };
            }
            Conn.Close();
            return tmp;
        }

        public static List<Product> GetAll()
        {
            string ConnStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True";
            SqlConnection Conn = new SqlConnection(ConnStr);
            Conn.Open();
            string Sql = $"SELECT * FROM T.Product";
            SqlCommand cmd = new SqlCommand(Sql, Conn);
            SqlDataReader Dr = cmd.ExecuteReader();
            List<Product> tmp = new List<Product>();
            while (Dr.Read() == true)
            {
                tmp.Add(new Product()
                {
                    Pid = (int)Dr["Pid"],
                    Pname = Dr["Pname"].ToString(),
                    Price = (float)Dr["Price"],
                    Pdesc = Dr["Pdesc"].ToString(),
                    Cid = (int)Dr["Cid"],
                    Picname = (string)Dr["Picname"]
                });
            }
            /*foreach (DataRow dr in Dr)
            {
                if (dr != null)
                {
                    tmp.Add(new Product()
                    {
                        Pid = (int)Dr["Pid"],
                        Pname = Dr["Pname"].ToString(),
                        Price = (float)Dr["Price"],
                        Pdesc = Dr["Pdesc"].ToString(),
                        Cid = (int)Dr["Cid"],
                        Picname = (string)Dr["Picname"]
                    });
                }
            }*/

            Conn.Close();

            return tmp;
        }

        public static void Save(Product p)
        {
            string ConnStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True";
            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {
                Conn.Open();
                string Sql = "INSERT INTO T.Product (Pname, Price, Pdesc, Cid, Picname) VALUES (@Pname, @Price, @Pdesc, @Cid, @Picname)";
                SqlCommand cmd = new SqlCommand(Sql, Conn);
                cmd.Parameters.AddWithValue("@Pname", p.Pname);
                cmd.Parameters.AddWithValue("@Price", p.Price);
                cmd.Parameters.AddWithValue("@Pdesc", p.Pdesc);
                cmd.Parameters.AddWithValue("@Cid", p.Cid);
                cmd.Parameters.AddWithValue("@Picname", p.Picname);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
        }

        public static void Update(Product p)
        {
            string ConnStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True";
            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {
                Conn.Open();
                string Sql = "UPDATE T.Product SET Pname = @Pname, Price = @Price, Pdesc = @Pdesc, Cid = @Cid, Picname = @Picname WHERE Pid = @Pid";
                SqlCommand cmd = new SqlCommand(Sql, Conn);
                cmd.Parameters.AddWithValue("@Pname", p.Pname);
                cmd.Parameters.AddWithValue("@Price", p.Price);
                cmd.Parameters.AddWithValue("@Pdesc", p.Pdesc);
                cmd.Parameters.AddWithValue("@Cid", p.Cid);
                cmd.Parameters.AddWithValue("@Picname", p.Picname);
                cmd.Parameters.AddWithValue("@Pid", p.Pid);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
        }


        public static int DeleteByID(int pid)
        {
            string ConnStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True";
            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {
                Conn.Open();
                string Sql = "DELETE FROM T.Product WHERE Pid = @Pid";
                SqlCommand cmd = new SqlCommand(Sql, Conn);
                cmd.Parameters.AddWithValue("@Pid", pid);
                int rowsAffected = cmd.ExecuteNonQuery();
                Conn.Close();

                if (rowsAffected > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }


    }
}
    

 