using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using DATA;

namespace DAL
{
    public class UserDAL
    {
        public static Users GetByID(int uid)
        {
            DbContext db = new DbContext();
            string Sql = $"SELECT * FROM T.User WHERE Uid = {uid}";
            DataTable dt = db.Execute(Sql);
            Users tmp = null;

            if (dt.Rows.Count > 0)
            {
                tmp = new Users()
                {
                    Uid = (int)dt.Rows[0]["Uid"],
                    Fname = dt.Rows[0]["Fname"].ToString(),
                    Email = dt.Rows[0]["Email"].ToString(),
                    Pass = dt.Rows[0]["Pass"].ToString(),
                    Address = dt.Rows[0]["Address"].ToString(),
                    Phone = dt.Rows[0]["Phone"].ToString()
                };
            }

            db.Close();
            return tmp;
        }

        public static List<Users> GetAll()
        {
            DbContext db = new DbContext();
            string Sql = "SELECT * FROM T.User";
            DataTable dt = db.Execute(Sql);
            List<Users> users = new List<Users>();

            foreach (DataRow row in dt.Rows)
            {
                Users tmp = new Users()
                {
                    Uid = (int)row["Uid"],
                    Fname = row["Fname"].ToString(),
                    Email = row["Email"].ToString(),
                    Pass = row["Pass"].ToString(),
                    Address = row["Address"].ToString(),
                    Phone = row["Phone"].ToString()
                };
                users.Add(tmp);
            }

            db.Close();
            return users;
        }

        public static void Save(Users u)
        {
            DbContext db = new DbContext();
            string Sql;

            if (u.Uid == -1)
            {
                Sql = $"INSERT INTO T.User (Fname, Email, Pass, Address, Phone) " +
                      $"VALUES (N'{u.Fname}', N'{u.Email}', N'{u.Pass}', N'{u.Address}', N'{u.Phone}')";
            }
            else
            {
                Sql = $"UPDATE T.User SET " +
                      $"Fname = N'{u.Fname}', " +
                      $"Email = N'{u.Email}', " +
                      $"Pass = N'{u.Pass}', " +
                      $"Address = N'{u.Address}', " +
                      $"Phone = N'{u.Phone}' " +
                      $"WHERE Uid = {u.Uid}";
            }

            db.ExecuteNonQuery(Sql);

            if (u.Uid == -1)
            {
                Sql = $"SELECT MAX(Uid) FROM T.User WHERE Email = N'{u.Email}'";
                u.Uid = (int)db.ExecuteScalar(Sql);
            }

            db.Close();
        }

        public static int DeleteByID(int uid)
        {
            DbContext db = new DbContext();
            string Sql = $"DELETE FROM T.User WHERE Uid = {uid}";
            int retval = db.ExecuteNonQuery(Sql);
            db.Close();
            return retval;
        }
    }
}
