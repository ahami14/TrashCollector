using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomersController : Controller
    {
        ApplicationDbContext context;

        public CustomersController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Customers
        public ActionResult Index()//this will end up being the details page, since this will be the home page for customers
        {
            var currentUser = User.Identity.GetUserId();
            var customer1 = context.Customers.Where(c => c.ApplicationId == currentUser).FirstOrDefault();//pass in application id and compare to customer id
            return View(customer1);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            var customer1 = context.Customers.Where(c => c.Id == id).FirstOrDefault();
            return View(customer1);
        }

        // GET: Customers/Create/ more like creating a profile then customer
        public ActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                Customer customer1 = context.Customers.Where(c => c.Id == customer.Id).FirstOrDefault();
                context.Customers.Add(customer);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            var customer1 = context.Customers.Where(c => c.Id == id).FirstOrDefault();
            return View();
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                var editCustomer1 = context.Customers.Where(c => c.Id == id).FirstOrDefault();
                editCustomer1.firstName = customer.firstName;
                editCustomer1.lastName = customer.lastName;
                editCustomer1.streetAddress = customer.streetAddress;
                editCustomer1.cityName = customer.cityName;
                editCustomer1.stateName = customer.stateName;
                editCustomer1.zipCode = customer.zipCode;
                editCustomer1.startDate = customer.startDate;
                editCustomer1.endDate = customer.endDate;

                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            var customer1 = context.Customers.Where(c => c.Id == id).FirstOrDefault();
            return View();
        }

        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                // TODO: Add delete logic here
                var deleteCustomer1 = context.Customers.Where(c => c.Id == id).FirstOrDefault();
                context.Customers.Remove(deleteCustomer1);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
