using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Diagnostics;
using DATA;
using System.Xml;

namespace DAL
{
    public class ProductDAL
    {
        public static Product GetbyID(int pid)
        {
            DbContext db = new DbContext();
            string Sql = $"SELECT * FROM T_Product WHERE Pid = {pid}";

            DataTable dt = db.Execute(Sql);
            Product tmp = null;

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                tmp = new Product()
                {
                    Pid = Convert.ToInt32(row["Pid"]),
                    Pname = row["Pname"].ToString(),
                    Price = Convert.ToSingle(row["Price"]),
                    Pdesc = row["Pdesc"].ToString(),
                    Cid = Convert.ToInt32(row["Cid"]),
                    Picname = row["Picname"].ToString()
                };
            }

            db.Close();
            return tmp;
        }

        public static List<Product> GetAll()
        {
            DbContext db = new DbContext();
            string Sql = $"SELECT * FROM T_Product";
            DataTable dt = db.Execute(Sql);
            List<Product> products = new List<Product>();

            foreach (DataRow row in dt.Rows)
            {
                Product tmp = new Product()
                {
                    Pid = (int)row["Pid"],
                    Pname = row["Pname"].ToString(),
                    Price = Convert.ToSingle(row["Price"]),
                    Pdesc = row["Pdesc"].ToString(),
                    Cid = (int)row["Cid"],
                    Picname = row["Picname"].ToString()
                };
                products.Add(tmp);
            }

            db.Close();
            return products;
        }


        public static void Save(Product p)
        {
            DbContext db = new DbContext();
            string Sql;

            if (p.Pid == -1)
            {
                Sql = $"INSERT INTO T_Product (Pname, Price, Pdesc, Cid, Picname, Status) " +
                      $"VALUES (N'{p.Pname}', {p.Price}, N'{p.Pdesc}', {p.Cid}, N'{p.Picname}', {p.Status})";
            }
            else
            {
                Sql = $"UPDATE T_Product SET " +
                      $"Pname = N'{p.Pname}', " +
                      $"Price = {p.Price}, " +
                      $"Pdesc = N'{p.Pdesc}', " +
                      $"Cid = {p.Cid}, " +
                      $"Picname = N'{p.Picname}', " +
                      $"Status = {p.Status} " +
                      $"WHERE Pid = {p.Pid}";
            }
            int retval = db.ExecuteNonQuery(Sql);
            if (p.Pid == -1)
            {
                Sql = $"SELECT MAX(Pid) FROM T_Product Where Pname='{p.Pname}'";
                p.Pid=(int)db.ExecuteScalar(Sql);
            }
            db.Close();
        }


        public static int DeleteByID(int pid)
        {
            DbContext db = new DbContext();
            string Sql = $"DELETE FROM T_Product WHERE Pid = {pid}";
            int retval = db.ExecuteNonQuery(Sql);
            db.Close();
            return retval;
        }
    }
}
    

 