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

        public Category Get(int id)
        {
            return Category.GetByID(id);
        }

        public int Post([FromBody] Category category)
        {
            return category.Save();
        }

        public int Put(int id, [FromBody] Category category)
        {
            category.Cid = id;
            return category.Save();
        }

        public void Delete(int id)
        {
            Category.DeleteByID(id);
        }
    }
}
