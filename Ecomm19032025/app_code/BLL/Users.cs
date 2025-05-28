using System;
using System.Collections.Generic;
using DAL;

namespace BLL
{
    public class Users
    {
        // Uid, Fname, Email, Pass, Address, Phone
        public int Uid { get; set; } = -1;
        public string Fname { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public static Users GetByID(int uid)
        {
            return UsersDAL.GetByID(uid);
        }

        public static List<Users> GetAll()
        {
            return UsersDAL.GetAll();
        }

        public static Users CheckLogin(string Email, string Pass)
        {
            return UsersDAL.CheckLogin(Email, Pass);
        }
        public int Save()
        {
            UsersDAL.Save(this);
            return Uid;
        }

        public static int DeleteByID(int uid)
        {
            return UsersDAL.DeleteByID(uid);
        }
    }
}
