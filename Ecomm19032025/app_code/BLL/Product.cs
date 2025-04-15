using System;
using System.Collections.Generic;
using DAL;

namespace BLL
{
    public class Product
    {
        // Pid, Pname, Price, Picname, Pdesc, Cid, Status
        public int Pid { get; set; } = -1;
        public string Pname { get; set; }
        public float Price { get; set; }
        public string Picname { get; set; }
        public string Pdesc { get; set; }
        public int Cid { get; set; }
        public int Status { get; set; }

        public static Product GetbyID(int pid)
        {
            return ProductDAL.GetbyID(pid);
        }

        public static List<Product> GetAll()
        {
            return ProductDAL.GetAll();
        }

        public int Save()
        {
            ProductDAL.Save(this);
            return Pid;
        }

        public static int DeleteByID(int pid)
        {
            return ProductDAL.DeleteByID(pid);
        }

    }
}
