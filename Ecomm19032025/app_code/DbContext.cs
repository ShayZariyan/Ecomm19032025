using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using BLL;
using System.Security.Cryptography;
using System.Drawing;

namespace DATA
{
    public class DbContext
    {
        public string ConnStr { get; set; }
        public SqlConnection Conn { get; set; }

        public DbContext()
        {
            try
            {
               
                string ConnStr = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Shayz\source\repos\Ecomm19032025\Ecomm19032025\App_Data\EcommDB.mdf;Integrated Security=True;Connect Timeout=30;";
                Conn = new SqlConnection(ConnStr);
                Conn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("❌ שגיאה בפתיחת החיבור למסד הנתונים: " + ex.Message);
            }
        }

        public void Close()
        {
            if (Conn != null && Conn.State == ConnectionState.Open)
                Conn.Close();
        }

        public int ExecuteNonQuery(string Sql)
        {
            if (Conn == null || Conn.State != ConnectionState.Open)
                throw new InvalidOperationException("⚠ החיבור למסד הנתונים אינו פתוח.");

            using (SqlCommand cmd = new SqlCommand(Sql, Conn))
            {
                return cmd.ExecuteNonQuery();
            }
        }

        public DataTable Execute(string Sql)
        {
            if (Conn == null || Conn.State != ConnectionState.Open)
                throw new InvalidOperationException("⚠ החיבור למסד הנתונים אינו פתוח.");

            using (SqlCommand cmd = new SqlCommand(Sql, Conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public object ExecuteScalar(string Sql)
        {
            if (Conn == null || Conn.State != ConnectionState.Open)
                throw new InvalidOperationException("⚠ החיבור למסד הנתונים אינו פתוח.");

            using (SqlCommand cmd = new SqlCommand(Sql, Conn))
            {
                return cmd.ExecuteScalar();
            }
        }
    }
}