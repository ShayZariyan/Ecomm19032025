using BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace DAL
{
    public class UserDAL
    {
        private static readonly string ConnStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True";

        public static Users GetByID(int uid)
        {
            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {
                Conn.Open();
                string Sql = "SELECT * FROM T.User WHERE Uid = @Uid";
                SqlCommand cmd = new SqlCommand(Sql, Conn);
                cmd.Parameters.AddWithValue("@Uid", uid);
                SqlDataReader Dr = cmd.ExecuteReader();
                Users tmp = null;
                if (Dr.Read())
                {
                    tmp = new Users()
                    {
                        Uid = (int)Dr["Uid"],
                        Fname = Dr["Fname"].ToString(),
                        Email = Dr["Email"].ToString(),
                        Pass = Dr["Pass"].ToString(),
                        Address = Dr["Address"].ToString(),
                        Phone = Dr["Phone"].ToString()
                    };
                }
                return tmp;
            }
        }

        public static List<Users> GetAll()
        {
            List<Users> users = new List<Users>();
            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {
                Conn.Open();
                string Sql = "SELECT * FROM T.User";
                SqlCommand cmd = new SqlCommand(Sql, Conn);
                SqlDataReader Dr = cmd.ExecuteReader();
                while (Dr.Read())
                {
                    users.Add(new Users()
                    {
                        Uid = (int)Dr["Uid"],
                        Fname = Dr["Fname"].ToString(),
                        Email = Dr["Email"].ToString(),
                        Pass = Dr["Pass"].ToString(),
                        Address = Dr["Address"].ToString(),
                        Phone = Dr["Phone"].ToString()
                    });
                }
            }
            return users;
        }

        public static void Save(Users u)
        {
            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {
                Conn.Open();
                string Sql = "INSERT INTO T.User (Fname, Email, Pass, Address, Phone) VALUES (@Fname, @Email, @Pass, @Address, @Phone)";
                SqlCommand cmd = new SqlCommand(Sql, Conn);
                cmd.Parameters.AddWithValue("@Fname", u.Fname);
                cmd.Parameters.AddWithValue("@Email", u.Email);
                cmd.Parameters.AddWithValue("@Pass", u.Pass);
                cmd.Parameters.AddWithValue("@Address", u.Address);
                cmd.Parameters.AddWithValue("@Phone", u.Phone);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(Users u)
        {
            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {
                Conn.Open();
                string Sql = "UPDATE T.User SET Fname = @Fname, Email = @Email, Pass = @Pass, Address = @Address, Phone = @Phone WHERE Uid = @Uid";
                SqlCommand cmd = new SqlCommand(Sql, Conn);
                cmd.Parameters.AddWithValue("@Fname", u.Fname);
                cmd.Parameters.AddWithValue("@Email", u.Email);
                cmd.Parameters.AddWithValue("@Pass", u.Pass);
                cmd.Parameters.AddWithValue("@Address", u.Address);
                cmd.Parameters.AddWithValue("@Phone", u.Phone);
                cmd.Parameters.AddWithValue("@Uid", u.Uid);
                cmd.ExecuteNonQuery();
            }
        }

        public static int DeleteByID(int uid)
        {
            string ConnStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EcommDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True";
            using (SqlConnection Conn = new SqlConnection(ConnStr))
            {
                Conn.Open();
                string Sql = "DELETE FROM T.User WHERE Uid = @Uid";
                SqlCommand cmd = new SqlCommand(Sql, Conn);
                cmd.Parameters.AddWithValue("@Uid", uid);
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
