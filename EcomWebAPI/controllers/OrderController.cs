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

        public Order Get(int id)
        {
            return Order.GetByID(id);
        }

        [HttpGet]
        [Route("api/Orders/byuser/{uid}")]
        public List<Order> GetOrdersByUser(int uid)
        {
            return Order.GetOrdersByUser(uid);
        }

        public int Post([FromBody] Order order)
        {
            return order.Save();
        }

        public int Put(int id, [FromBody] Order order)
        {
            order.Oid = id;
            return order.Save();
        }

        public void Delete(int id)
        {
            Order.DeleteByID(id);
        }
    }
}
