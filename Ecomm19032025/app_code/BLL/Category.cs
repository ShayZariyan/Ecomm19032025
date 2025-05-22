using System;
using System.Collections.Generic;
using DAL;

namespace BLL
{
    public class Category
    {
        public int Cid { get; set; } = -1;
        public string Cname { get; set; }
        public string Cdesc { get; set; }

        public static Category GetByID(int cid)
        {
            return CategoryDAL.GetByID(cid);
        }

        public static List<Category> GetAll()
        {
            return CategoryDAL.GetAll();
        }

        public int Save()
        {
            CategoryDAL.Save(this);
            return Cid;
        }

        public static int DeleteByID(int cid)
        {
            return CategoryDAL.DeleteByID(cid);
        }
    }
}
