using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using BookStore.ViewModels;
using System.Data.Entity;

namespace BookStore.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        

        // GET
        public ActionResult Index()
        {
            var movie = new Movie() { Name = "Harry Potter" };

            var customers = _context.customers.Include(c => c.MembershipType).ToList<Customer>();

           return View(customers);
        }

        [Route("customers/{id}")]
        public ActionResult CustomerDetail(int id)
        {
            var customer = _context.customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            return View(customer);
        }

        [Route("customers/new")]
        public ActionResult New()
        {
            var membershipTypes = _context.membershipTypes;
            var newCustomerViewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View(newCustomerViewModel);
        }

    }
}