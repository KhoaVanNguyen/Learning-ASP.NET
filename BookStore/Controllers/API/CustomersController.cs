using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BookStore.Models;

namespace BookStore.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public IEnumerable<Customer> customers { get; set; }

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // api/customers/
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }
        // api/customers/{id}
        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.customers.SingleOrDefault(m => m.Id == id);

            if (customer == null)
            {
                throw  new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return customerDto;
        }

        // PUT: api/customers/{id}
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDb = _context.customers.SingleOrDefault(m => m.Id == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);

            _context.SaveChanges();
        }
        // DELETE: api/customers/{id}
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.customers.SingleOrDefault(m => m.Id == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.customers.Remove(customerInDb);
            _context.SaveChanges();
        }

       

        


    }
}
