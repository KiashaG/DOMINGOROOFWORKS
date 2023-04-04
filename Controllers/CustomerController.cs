using DOMINGOROOFWORKSCLDV6211.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOMINGOROOFWORKSCLDV6211.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDAL customerDAL = new CustomerDAL();
        public IActionResult Index()
        {
            // GET ALL CUSTOMERS
            List<CustomerInfo> customerList = new List<CustomerInfo>();
            customerList = customerDAL.GetAllCustomers().ToList();

            return View(customerList);
          
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] CustomerInfo objCust)
        {
            if (ModelState.IsValid)
            {
                customerDAL.AddCustomer(objCust);
                //CustomerDAL.AddCustomer(objCust);
                return RedirectToAction("Index");
            }

            return View(objCust);
        }
        //GET CUSTOMER DETAILS
        [HttpGet]
        public IActionResult Details(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            CustomerInfo cust = customerDAL.GetCustomerById(ID);
            if (cust == null)
            {
                return NotFound();
            }
            return View(cust);
        }

        //Edit Customers
        public IActionResult Edit(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            CustomerInfo cust = customerDAL.GetCustomerById(ID);
            if (cust == null)
            {
                return NotFound();
            }

            return View(cust);
        }

        // UPDATE CUSTOMER
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? ID, [Bind] CustomerInfo objCust)
        {
            if (ID== null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                customerDAL.UpdateCustomer(objCust);
                return RedirectToAction("Index");
            }
            return View(customerDAL);
        }

        // GET THE DELETE VIEW
        public IActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            CustomerInfo cust = customerDAL.GetCustomerById(ID);
            if (cust == null)
            {
                return NotFound();
            }
            return View(cust);
        }

        // PERFORM THE DELETE OPTION
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCust(int? ID)
        {
            customerDAL.DeleteCustomer(ID);
            return RedirectToAction("Index");
        }


    }
}
