using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using DATA;

namespace DAL
{
    public class UsersDAL
    {
        public static Users GetByID(int uid)
        {
            DbContext db = new DbContext();
            string Sql = $"SELECT * FROM T_User WHERE Uid = {uid}";
            DataTable dt = db.Execute(Sql);
            Users tmp = null;

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                tmp = new Users()
                {
                    Uid = Convert.ToInt32(row["Uid"]),
                    Fname = row["Fname"].ToString(),
                    Email = row["Email"].ToString(),
                    Pass = row["Pass"].ToString(),
                    Address = row["Address"].ToString(),
                    Phone = row["Phone"].ToString()
                };
            }

            db.Close();
            return tmp;
        }

        public static List<Users> GetAll()
        {
            DbContext db = new DbContext();
            string Sql = "SELECT * FROM T_User";
            DataTable dt = db.Execute(Sql);
            List<Users> users = new List<Users>();

            foreach (DataRow row in dt.Rows)
            {
                Users tmp = new Users()
                {
                    Uid = Convert.ToInt32(row["Uid"]),
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
                Sql = $"INSERT INTO T_User (Fname, Email, Pass, Address, Phone) " +
                      $"VALUES (N'{u.Fname}', N'{u.Email}', N'{u.Pass}', N'{u.Address}', N'{u.Phone}')";
            }
            else
            {
                Sql = $"UPDATE T_User SET " +
                      $"Fname = N'{u.Fname}', " +
                      $"Email = N'{u.Email}', " +
                      $"Pass = N'{u.Pass}', " +
                      $"Address = N'{u.Address}', " +
                      $"Phone = N'{u.Phone}' " +
                      $"WHERE Uid = {u.Uid}";
            }

            int retval = db.ExecuteNonQuery(Sql);

            if (u.Uid == -1)
            {
                Sql = $"SELECT MAX(Uid) FROM T_User WHERE Email = N'{u.Email}'";
                u.Uid = (int)db.ExecuteScalar(Sql);
            }

            db.Close();
        }

        public static int DeleteByID(int uid)
        {
            DbContext db = new DbContext();
            string Sql = $"DELETE FROM T_User WHERE Uid = {uid}";
            int retval = db.ExecuteNonQuery(Sql);
            db.Close();
            return retval;
        }
    }
}
