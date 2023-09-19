using CustomerSystemApi.Models;
using CustomerSystemApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomerSystemApi.Controllers
{
    public class CustomerController : ApiController
    {
        CustomerService _service = new CustomerService();

        //GET: api/Customer
       [HttpGet]
        public IHttpActionResult Get()
        {
            var customers = _service.GetAllCustomer();
            return Ok(customers);
        }

        // GET: api/Customer/5
        [HttpGet]
        [Route("api/Customer/{id}")]
        public IHttpActionResult Get(int id)
        {
            var customer = _service.GetOneCustomer(id);
            return Ok(customer); 
        }

        // POST: api/Customer
        [HttpPost]
        public IHttpActionResult Post(string name, string phone, string email, string address) 
        {
            int num = 0;
            num = _service.InsertCustomer( name,  phone,  email,  address);
            return Ok(num);
        }

        // PUT: api/Customer/5
        [HttpPut]
        public IHttpActionResult Put(int id, string name, string phone, string email, string address)
        {
            int num = 0;
            num = _service.UpdateCustomer(id, name, phone, email, address);
            return Ok(num); ;
        }

        // DELETE: api/Customer/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            int num = 0;
            num = _service.DeleteCustomer(id);
            return Ok(num); 
        }
    }
}
