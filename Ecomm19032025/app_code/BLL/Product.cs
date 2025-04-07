using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
namespace BLL
{
    public class Product
    {
        //Pid,Pname,Price,Picname,Pdesc,Cid
        public int Pid { get; set; }
        public string Pname { get; set; }
        public float Price { get; set; }
        public string Picname { get; set; }
        public string Pdesc { get; set; }
        public int Cid { get; set; }

        public static Product GetbyID(int pid)
        {
            return ProductDAL.GetbyID(pid);
        }

        public static List<Product> GetAll()
        {
            return new List<Product>();
        }

        public int Save()
        {
            return 0;
        }
        public static int DeleteByID(int pid) 
        {
            return 0;
        }



    }
}