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
           return View();
        }

      //  [Route("customers/{id}")]
        public ActionResult CustomerDetail(int id)
        {
            var customer = _context.customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            return View(customer);
        }

        //[Route("customers/new")]
        public ActionResult New()
        {
            var membershipTypes = _context.membershipTypes;
            var newCustomerViewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",newCustomerViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if ( !ModelState.IsValid)
            {
                var customerViewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.membershipTypes.ToList()
                };
                return View("CustomerForm", customerViewModel);
            }

            if ( customer.Id == 0)
            {
                _context.customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.birthDate = customer.birthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubcribeToNewsletter = customer.IsSubcribeToNewsletter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }

        [Route("customers/edit/{id}")]
        public ActionResult Edit(int id)
        {
            var customer = _context.customers.SingleOrDefault(c => c.Id == id);
            if ( customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel {
                Customer = customer,
                MembershipTypes = _context.membershipTypes.ToList(),
            };

            return View("CustomerForm", viewModel);
        }

        [Route("customers/delete/{id}")]
        public ActionResult Delete(int id)
        {
            var customerInDb = _context.customers.Single(c => c.Id == id);

            _context.customers.Remove(customerInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");

        }

    }
}