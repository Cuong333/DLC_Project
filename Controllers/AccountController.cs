using DLC_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System;

namespace DemoDLC.Controllers
{
    public class AccountController : Controller
    {
        // Instantiate database context
        private readonly DemoDlcContext db;

        // Constructor to inject context if required
        public AccountController(DemoDlcContext context)
        {
            db = context;
        }

        // Login GET
        [HttpGet]
        public IActionResult Login()
        {
            // If the user is already logged in, redirect to the home page
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Index", "Home");
            }

            // If the user is not logged in, show the login page
            return View();
        }

        // Login POST
        [HttpPost]
        public IActionResult Login(Customer customer)
        {
            // If the user is already logged in, redirect to the home page
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                // Find the customer in the database using the provided username and password
                var cus = db.Customers.SingleOrDefault(x => x.Username == customer.Username && x.Password == customer.Password);

                if (cus != null)
                {
                    // Store the username in session
                    HttpContext.Session.SetString("Username", cus.Username);
                    return RedirectToAction("Index", "Home");
                }

                // If no matching customer is found, display an error message
                ViewBag.ErrorMessage = "Invalid username or password.";
            }

            return View(customer);
        }

        // Register GET
        [HttpGet]
        public IActionResult Register()
        {
            // If the user is already logged in, redirect to the home page
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Index", "Home");
            }

            // If the user is not logged in, show the registration page
            return View();
        }

        // Register POST
        [HttpPost]
        public IActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                // Check if the username already exists
                if (!CustomerExists(customer.Username))
                {
                    // Add the customer to the database
                    db.Customers.Add(customer);
                    db.SaveChanges();

                    // Store the username in session
                    HttpContext.Session.SetString("Username", customer.Username);
                    return RedirectToAction("Index", "Home");
                }

                // If the username already exists, show an error
                ModelState.AddModelError("", "Username already exists!");
            }

            // If model is invalid or username exists, return the form with the error message
            return View(customer);
        }

        // Helper method to check if a customer exists by username
        private bool CustomerExists(string username)
        {
            return db.Customers.Any(c => c.Username == username);
        }
    }
}
