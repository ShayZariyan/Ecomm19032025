using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EcomWebAPI.controllers
{
    public class CategoryController : ApiController
    {
        // GET: api/Category
        public List<Category> Get()
        {
            return Category.GetAll();
        }

        // GET: api/Categories/5
        public Category Get(int id)
        {
            return Category.GetByID(id);
        }

        // POST: api/Categories?cname=Electronics&cdesc=Smart Devices
        public int Post(string cname, string cdesc)
        {
            Category c = new Category
            {
                Cname = cname,
                Cdesc = cdesc
            };

            return c.Save();
        }

        // PUT: api/Categories/5?cname=Updated&cdesc=UpdatedDesc
        public int Put(int id, string cname, string cdesc)
        {
            Category c = new Category
            {
                Cid = id,
                Cname = cname,
                Cdesc = cdesc
            };

            return c.Save();
        }

        // DELETE: api/Categories/5
        public void Delete(int id)
        {
            Category.DeleteByID(id);
        }
    }
}
