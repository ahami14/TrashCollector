using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeesController : Controller
    {
        ApplicationDbContext context;

        public EmployeesController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Employees
        public ActionResult Index()//this will be a list of customers
        {
            //we may be able to call a method in here that allows you to see the details of said customer\

            // figure out which employee is logged in - Application ID
            //query for employee based on user ID
            //then you can use zip code to finish query below
            
            //var currentUser = User.Identity.GetUserId();
            
            //var employee1 = context.Employees.Where(e => e.ApplicationId == currentUser).FirstOrDefault();

            //var customers = context.Customers.Where(c => c.zipCode == employee1.zipCode).FirstOrDefault();

            var customers1 = context.Customers;
            return View(customers1);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            var employee1 = context.Employees.Where(e => e.Id == id).FirstOrDefault();
            return View(employee1);
        }

        // GET: Employees/Create/ wil probably be a create profile as well
        public ActionResult Create()
        {
            Employee employee = new Employee();

            return View(employee);
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                // TODO: Add insert logic here
                Employee employee1 = context.Employees.Where(e => e.Id == employee.Id).FirstOrDefault();
                var currentUser = User.Identity.GetUserId();
                employee.ApplicationId = currentUser;
                context.Employees.Add(employee);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            var employee1 = context.Employees.Where(e => e.Id == id).FirstOrDefault();
            return View(employee1);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                var editEmployee1 = context.Employees.Where(e => e.Id == id).FirstOrDefault();
                editEmployee1.zipCode = employee.zipCode;
                editEmployee1.confirmedPickup = employee.confirmedPickup;
                context.SaveChanges();
                // ConfirmPickup(customer, employee);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ConfirmPickup(int id)
        {
            Customer customer = context.Customers.Where(c => c.Id == id).FirstOrDefault();
            
            customer.confirmedPickup = true;
            customer.balanceDue += 20;
            context.SaveChanges();
            return RedirectToAction("Index");

            // save changes
            // redirect to index action
        }
    }
}
