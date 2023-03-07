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

        // GET: api/Customer
        public List<customer> Get()
        {
            var customers = _service.GetAllCustomer();
            return customers;
        }

        // GET: api/Customer/5
        public customer Get(int id)
        {
            var customer = _service.GetOneCustomer(id);
            return customer;
        }

        // POST: api/Customer
        public int Post(string name, string phone, string email, string address) 
        {
            int num = 0;
            num = _service.InsertCustomer( name,  phone,  email,  address);
            return num;
        }

        // PUT: api/Customer/5
        public int Put(int id, string name, string phone, string email, string address)
        {
            int num = 0;
            num = _service.UpdateCustomer(id, name, phone, email, address);
            return num;
        }

        // DELETE: api/Customer/5
        public int Delete(int id)
        {
            int num = 0;
            num = _service.DeleteCustomer(id);
            return num;
        }
    }
}
