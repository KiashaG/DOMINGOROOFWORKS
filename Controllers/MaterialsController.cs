using DOMINGOROOFWORKSCLDV6211.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOMINGOROOFWORKSCLDV6211.Controllers
{
    public class MaterialsController : Controller
    {
        MaterialsDAL materialsDAL = new MaterialsDAL();
        public IActionResult Index()
        {
            // GET ALL MATERIALS
            List<MaterialsInfo> materialList = new List<MaterialsInfo>();
            materialList = materialsDAL.GetAllMaterials().ToList();

            return View(materialList);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] MaterialsInfo objMat)
        {
            if (ModelState.IsValid)
            {
                materialsDAL.AddMaterials(objMat);
                return RedirectToAction("Index");
            }

            return View(objMat);
        }
        //GET MATERIALS DETAILS
        [HttpGet]
        public IActionResult Details(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            MaterialsInfo mat = materialsDAL.GetMaterialsById(ID);
            if (mat == null)
            {
                return NotFound();
            }
            return View(mat);
        }

        //EDIT MATERIALS
        public IActionResult Edit(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            MaterialsInfo mat = materialsDAL.GetMaterialsById(ID);
            if (mat == null)
            {
                return NotFound();
            }

            return View(mat);
        }
        // UPDATE MATERIALS
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? ID, [Bind] MaterialsInfo objMat)
        {
            if (ID == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                materialsDAL.UpdateMaterials(objMat);
                return RedirectToAction("Index");
            }
            return View(materialsDAL);
        }

        // GET THE DELETE VIEW
        public IActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
           MaterialsInfo mat = materialsDAL.GetMaterialsById(ID);
            if (mat == null)
            {
                return NotFound();
            }
            return View(mat);
        }

        // PERFORM THE DELETE OPTION
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteMat(int? ID)
        {
            materialsDAL.DeleteMaterial(ID);
            return RedirectToAction("Index");
        }


    }
}


    

