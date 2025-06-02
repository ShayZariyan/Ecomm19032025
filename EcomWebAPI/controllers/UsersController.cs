using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;


namespace EcomWebAPI.Controller
    {
        public class UsersController : ApiController
        {
            public List<Users> Get()
            {
                return Users.GetAll();
            }

            public Users Get(int id)
            {
                return Users.GetByID(id);
            }

            public int Post([FromBody] Users user)
            {
                return user.Save();
            }

            public int Put(int id, [FromBody] Users user)
            {
                user.Uid = id;
                return user.Save();
            }

            public void Delete(int id)
            {
                Users.DeleteByID(id);
            }
        }
    }


