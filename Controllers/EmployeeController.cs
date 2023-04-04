using DOMINGOROOFWORKSCLDV6211.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOMINGOROOFWORKSCLDV6211.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAL employeeDAL = new EmployeeDAL();
        public IActionResult Index()
        {
            // GET ALL EMPLOYEES
            List<EmployeeInfo> employeeList = new List<EmployeeInfo>();
            employeeList = employeeDAL.GetAllEmployees().ToList();

            return View(employeeList);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] EmployeeInfo objEmp)
        {
            if (ModelState.IsValid)
            {
                employeeDAL.AddEmployee(objEmp);
          
                return RedirectToAction("Index");
            }

            return View(objEmp);
        }
        //GET EMPLOYEE DETAILS
        [Route("Employee/Details/ID")]
        [HttpGet]
        public IActionResult Details(string ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            EmployeeInfo emp = employeeDAL.GetEmployeeById(ID);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }
        //EDIT EMPLOYEES
        public IActionResult Edit(string ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            EmployeeInfo emp = employeeDAL.GetEmployeeById(ID);
            if (emp == null)
            {
                return NotFound();
            }

            return View(emp);
        }
        // UPDATE EMPLOYEE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string ID, [Bind] EmployeeInfo objEmp)
        {
            if (ID == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                employeeDAL.UpdateEmployees(objEmp);
                return RedirectToAction("Index");
            }
            return View(employeeDAL);
        }
        // GET THE DELETE VIEW
        public IActionResult Delete(string ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            EmployeeInfo emp = employeeDAL.GetEmployeeById(ID);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }
        // PERFORM THE DELETE OPTION
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmp(string ID)
        {
            employeeDAL.DeleteEmployee(ID);
            return RedirectToAction("Index");
        }


    }
}