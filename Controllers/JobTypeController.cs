using DOMINGOROOFWORKSCLDV6211.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOMINGOROOFWORKSCLDV6211.Controllers
{
    public class JobTypeController : Controller
    {
        JobTypeDAL jobtypeDAL = new JobTypeDAL();
        public IActionResult Index()
        {
            // 
            List<JobTypeInfo> jobtypeList = new List<JobTypeInfo>();
            jobtypeList = jobtypeDAL.GetAllJobTypes().ToList();

            return View(jobtypeList);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] JobTypeInfo objJT)
        {
            if (ModelState.IsValid)
            {
                jobtypeDAL.AddJobType(objJT);
                return RedirectToAction("Index");
            }

            return View(objJT);
        }
        //GET JOBTYPE DETAILS
        [HttpGet]
        public IActionResult Details(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            JobTypeInfo JT = jobtypeDAL.GetJobTypeById(ID);
            if (JT == null)
            {
                return NotFound();
            }
            return View(JT);
        }

        //EDIT JOBTYPES
        [Route("JobType/Edit/ID")]
        public IActionResult Edit(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            JobTypeInfo JT = jobtypeDAL.GetJobTypeById(ID);
            if (JT == null)
            {
                return NotFound(JT);
            }

            return View(JT);
        }

        // UPDATE JOBTYPES
        [Route("JobType/Edit/ID")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? ID, [Bind] JobTypeInfo objJT)
        {
            if (ID == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                jobtypeDAL.UpdateJobTypes(objJT);
                return RedirectToAction("Index");
            }
            return View(jobtypeDAL);
        }
        // GET THE DELETE VIEW
        public IActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            JobTypeInfo JT = jobtypeDAL.GetJobTypeById(ID);
            if (JT == null)
            {
                return NotFound();
            }
            return View(JT);
        }

        // PERFORM THE DELETE OPTION
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteJT(int? ID)
        {
            jobtypeDAL.DeleteJobType(ID);
            return RedirectToAction("Index");
        }

    }
}
