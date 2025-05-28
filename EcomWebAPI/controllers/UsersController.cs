using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EcomWebAPI.controllers
{
    public class UsersController : ApiController
    {
        // GET: api/Users
        public List<Users> Get()
        {
            return Users.GetAll();
        }

        // GET: api/Users/5
        public Users Get(int id)
        {
            return Users.GetByID(id);
        }

        // POST: api/Users
        public int Post(string fname, string email, string pass, string address, string phone)
        {
            Users u = new Users
            {
                Fname = fname,
                Email = email,
                Pass = pass,
                Address = address,
                Phone = phone
            };

            return u.Save();
        }

        // PUT: api/Users/5
        public int Put(int id, string fname, string email, string pass, string address, string phone)
        {
            Users u = new Users
            {
                Uid = id,
                Fname = fname,
                Email = email,
                Pass = pass,
                Address = address,
                Phone = phone
            };

            return u.Save();
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
            Users.DeleteByID(id);
        }
    }
}

