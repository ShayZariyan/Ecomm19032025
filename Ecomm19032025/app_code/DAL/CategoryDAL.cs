using BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL
{
    public class CategoryDAL
    {
        private static readonly string ConnStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True";

        public static Category GetByID(int cid)
        {
            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {
                Conn.Open();
                string Sql = "SELECT * FROM T.Category WHERE Cid = @Cid";
                SqlCommand cmd = new SqlCommand(Sql, Conn);
                cmd.Parameters.AddWithValue("@Cid", cid);
                SqlDataReader Dr = cmd.ExecuteReader();
                Category tmp = null;
                if (Dr.Read())
                {
                    tmp = new Category()
                    {
                        Cid = (int)Dr["Cid"],
                        Cname = Dr["Cname"].ToString(),
                        Cdesc = Dr["Cdesc"].ToString()
                    };
                }
                return tmp;
            }
        }

        public static List<Category> GetAll()
        {
            List<Category> categories = new List<Category>();

            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {
                Conn.Open();
                string Sql = "SELECT * FROM T.Category";
                SqlCommand cmd = new SqlCommand(Sql, Conn);
                SqlDataReader Dr = cmd.ExecuteReader();

                while (Dr.Read())
                {
                    categories.Add(new Category()
                    {
                        Cid = (int)Dr["Cid"],
                        Cname = Dr["Cname"].ToString(),
                        Cdesc = Dr["Cdesc"].ToString()
                    });
                }
            }

            return categories;
        }

        public static void Save(Category c)
        {
            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {
                Conn.Open();
                string Sql = "INSERT INTO T.Category (Cname, Cdesc) VALUES (@Cname, @Cdesc)";
                SqlCommand cmd = new SqlCommand(Sql, Conn);
                cmd.Parameters.AddWithValue("@Cname", c.Cname);
                cmd.Parameters.AddWithValue("@Cdesc", c.Cdesc);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(Category c)
        {
            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {
                Conn.Open();
                string Sql = "UPDATE T.Category SET Cname = @Cname, Cdesc = @Cdesc WHERE Cid = @Cid";
                SqlCommand cmd = new SqlCommand(Sql, Conn);
                cmd.Parameters.AddWithValue("@Cname", c.Cname);
                cmd.Parameters.AddWithValue("@Cdesc", c.Cdesc);
                cmd.Parameters.AddWithValue("@Cid", c.Cid);
                cmd.ExecuteNonQuery();
            }
        }

        public static int DeleteByID(int cid)
        {
            string ConnStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True";
            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {
                Conn.Open();
                string Sql = "DELETE FROM T.Category WHERE Cid = @Cid";
                SqlCommand cmd = new SqlCommand(Sql, Conn);
                cmd.Parameters.AddWithValue("@Cid", cid);
                int rowsAffected = cmd.ExecuteNonQuery();
                Conn.Close();

                if (rowsAffected > 0)
                    return 1;
                else
                    return 0;
            }
        }

    }
}