using DOMINGOROOFWORKSCLDV6211.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOMINGOROOFWORKSCLDV6211.Controllers
{
    public class InvoiceController : Controller
    {
        InvoiceDAL invoiceDAL = new InvoiceDAL();
        public IActionResult Index()
        {
            // GET ALL INVOICES
            List<InvoiceInfo> invoiceList = new List<InvoiceInfo>();
            invoiceList = invoiceDAL.GetAllInvoices().ToList();

            return View(invoiceList);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] InvoiceInfo objInv)
        {
            if (ModelState.IsValid)
            {
                invoiceDAL.AddInvoices(objInv);
                return RedirectToAction("Index");
            }

            return View(objInv);
        }
        //GET INVOICE DETAILS
        [HttpGet]
        public IActionResult Details(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            InvoiceInfo inv = invoiceDAL.GetInvoiceById(ID);
            if (inv == null)
            {
                return NotFound();
            }
            return View(inv);
        }
        //Edit Invoices
        public IActionResult Edit(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            InvoiceInfo inv = invoiceDAL.GetInvoiceById(ID);
            if (inv == null)
            {
                return NotFound();
            }

            return View(inv);
        }

        // UPDATE INVOICE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? ID, [Bind] InvoiceInfo objInv)
        {
            if (ID == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                invoiceDAL.UpdateInvoices(objInv);
                return RedirectToAction("Index");
            }
            return View(invoiceDAL);
        }

        // GET THE DELETE VIEW
        public IActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            InvoiceInfo inv = invoiceDAL.GetInvoiceById(ID);
            if (inv == null)
            {
                return NotFound();
            }
            return View(inv);
        }
        // PERFORM THE DELETE OPTION
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteInv(int? ID)
        {
            invoiceDAL.DeleteInvoice(ID);
            return RedirectToAction("Index");
        }



    }
}
