using DOMINGOROOFWORKSCLDV6211.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOMINGOROOFWORKSCLDV6211.Controllers
{
    public class JobController : Controller
    {
        JobDAL jobDAL = new JobDAL();
        public IActionResult Index()
        {
            // GET ALL JOBS
            List<JobInfo> jobList = new List<JobInfo>();
            jobList = jobDAL.GetAllJobs().ToList();

            return View(jobList);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] JobInfo objJB)
        {
            if (ModelState.IsValid)
            {
                jobDAL.AddJob(objJB);
                return RedirectToAction("Index");
            }

            return View(objJB);
        }
        //GET JOB DETAILS
        [HttpGet]
        public IActionResult Details(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            JobInfo JB = jobDAL.GetJobById(ID);
            if (JB == null)
            {
                return NotFound();
            }
            return View(JB);
        }
        //EDIT JOBS
        public IActionResult Edit(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            JobInfo JB = jobDAL.GetJobById(ID);
            if (JB == null)
            {
                return NotFound();
            }

            return View(JB);
        }

        // UPDATE JOB
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? ID, [Bind] JobInfo objJB)
        {
            if (ID == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                jobDAL.UpdateJob(objJB);
                return RedirectToAction("Index");
            }
            return View(jobDAL);
        }

        // GET THE DELETE VIEW
        public IActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            JobInfo JB = jobDAL.GetJobById(ID);
            if (JB == null)
            {
                return NotFound();
            }
            return View(JB);
        }

        // PERFORM THE DELETE OPTION
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteJB(int? ID)
        {
            jobDAL.DeleteJob(ID);
            return RedirectToAction("Index");
        }


    }
}


    

