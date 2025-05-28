using System;
using BLL;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EcomWebAPI.controllers
{
    public class ProductController : ApiController
    {
        // GET: api/Product
        // GET: api/Products
        public List<Product> Get()
        {
            return Product.GetAll();
        }

        // GET: api/Products/5
        public Product Get(int id)
        {
            return Product.GetbyID(id);
        }

        // POST: api/Products?pname=...&price=...&picname=...&pdesc=...&cid=...&status=...
        public int Post(string pname, float price, string picname, string pdesc, int cid, int status)
        {
            Product p = new Product
            {
                Pname = pname,
                Price = price,
                Picname = picname,
                Pdesc = pdesc,
                Cid = cid,
                Status = status
            };

            return p.Save();
        }

        // PUT: api/Products/5?pname=...&price=...&picname=...&pdesc=...&cid=...&status=...
        public int Put(int id, string pname, float price, string picname, string pdesc, int cid, int status)
        {
            Product p = new Product
            {
                Pid = id,
                Pname = pname,
                Price = price,
                Picname = picname,
                Pdesc = pdesc,
                Cid = cid,
                Status = status
            };

            return p.Save();
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
            Product.DeleteByID(id);
        }
    }
}
