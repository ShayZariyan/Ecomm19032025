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

        public Product Get(int id)
        {
            return Product.GetbyID(id);
        }

        public int Post([FromBody] Product product)
        {
            return product.Save();
        }

        public int Put(int id, [FromBody] Product product)
        {
            product.Pid = id;
            return product.Save();
        }

        public void Delete(int id)
        {
            Product.DeleteByID(id);
        }
    }
}
