using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EcomWebAPI.controllers
{
    public class OrderController : ApiController
    {
        // GET: api/Order
        public List<Order> Get()
        {
            return Order.GetAll();
        }

        // GET: api/Orders/5
        public Order Get(int id)
        {
            return Order.GetByID(id);
        }

        // GET: api/Orders/byuser/3
        [HttpGet]
        [Route("api/Orders/byuser/{uid}")]
        public List<Order> GetOrdersByUser(int uid)
        {
            return Order.GetOrdersByUser(uid);
        }

        // POST: api/Orders?uid=3&totalAmount=199.99&status=חדש
        public int Post(int uid, float totalAmount, string status)
        {
            Order o = new Order
            {
                Uid = uid,
                TotalAmount = totalAmount,
                Status = status,
                OrderDate = DateTime.Now
            };

            return o.Save();
        }

        // PUT: api/Orders/5?uid=3&totalAmount=150.50&status=שולם
        public int Put(int id, int uid, float totalAmount, string status)
        {
            Order o = new Order
            {
                Oid = id,
                Uid = uid,
                TotalAmount = totalAmount,
                Status = status,
                OrderDate = DateTime.Now
            };

            return o.Save();
        }

        // DELETE: api/Orders/5
        public void Delete(int id)
        {
            Order.DeleteByID(id);
        }
    }
}
