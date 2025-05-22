using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using DATA;

namespace DAL
{
    public class CategoryDAL
    {
        public static Category GetByID(int cid)
        {
            DbContext db = new DbContext();
            string Sql = $"SELECT * FROM T_Category WHERE Cid = {cid}";
            DataTable dt = db.Execute(Sql);
            Category tmp = null;

            if (dt.Rows.Count > 0)
            {
                tmp = new Category()
                {
                    Cid = (int)dt.Rows[0]["Cid"],
                    Cname = dt.Rows[0]["Cname"].ToString(),
                    Cdesc = dt.Rows[0]["Cdesc"].ToString()
                };
            }

            db.Close();
            return tmp;
        }

        public static List<Category> GetAll()
        {
            DbContext db = new DbContext();
            string Sql = "SELECT * FROM T_Category";
            DataTable dt = db.Execute(Sql);
            List<Category> categories = new List<Category>();

            foreach (DataRow row in dt.Rows)
            {
                Category tmp = new Category()
                {
                    Cid = (int)row["Cid"],
                    Cname = row["Cname"].ToString(),
                    Cdesc = row["Cdesc"].ToString()
                };
                categories.Add(tmp);
            }

            db.Close();
            return categories;
        }

        public static void Save(Category c)
        {
            DbContext db = new DbContext();
            string Sql;

            if (c.Cid == -1)
            {
                Sql = $"INSERT INTO T_Category (Cname, Cdesc) VALUES (N'{c.Cname}', N'{c.Cdesc}')";
            }
            else
            {
                Sql = $"UPDATE T_Category SET Cname = N'{c.Cname}', Cdesc = N'{c.Cdesc}' WHERE Cid = {c.Cid}";
            }

            db.ExecuteNonQuery(Sql);

            if (c.Cid == -1)
            {
                Sql = $"SELECT MAX(Cid) FROM T_Category WHERE Cname = N'{c.Cname}'";
                c.Cid = (int)db.ExecuteScalar(Sql);
            }

            db.Close();
        }

        public static int DeleteByID(int cid)
        {
            DbContext db = new DbContext();
            string Sql = $"DELETE FROM T_Category WHERE Cid = {cid}";
            int retval = db.ExecuteNonQuery(Sql);
            db.Close();
            return retval;
        }
    }
}
