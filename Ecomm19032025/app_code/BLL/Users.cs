using System;
using System.Collections.Generic;
using DAL;

namespace BLL
{
    public class Users
    {
        public int Uid { get; set; }
        public string Fname { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public static Users GetByID(int uid)
        {
            return UserDAL.GetByID(uid);
        }

        public static List<Users> GetAll()
        {
            return UserDAL.GetAll();
        }

        public static int DeleteByID(int uid)
        {
            return UserDAL.DeleteByID(uid);
        }

        public int Save()
        {
            UserDAL.Save(this);
            return Uid;
        }
    }
}
