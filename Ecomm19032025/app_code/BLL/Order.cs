using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class Order
    {
        public int Oid { get; set; }
        public int Uid { get; set; }
        public float TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
    }
}