using BusinessAccessLayer.Abstract;
using BusinessAccessLayer.Implementation;
using ModelAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proper_LARCD1A_Trail1.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ICRUDLibrary _cRUDLibrary;
        public LibraryController()
        {
            _cRUDLibrary = new CRUDLibrary();
        }
        public LibraryController(ICRUDLibrary cRUDLibrary)
        {
            _cRUDLibrary = cRUDLibrary;
        }


        public ActionResult AddRecord()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRecord(CRUDLibraryModel cRUDLibraryModel)
        {
            if (_cRUDLibrary.AddBookRecord(cRUDLibraryModel))
            {
                ViewBag.Message = "Successfully Added";
            }
            return View();
        }
        public ActionResult GetList()
        {
            return View(_cRUDLibrary.GetListLibrary());
        }
        public ActionResult Edit(int id)
        {
            return View(_cRUDLibrary.EditLibRecordView(id));
        }
        [HttpPost]
        public ActionResult Edit(CRUDLibraryModel cRUDLibraryModel)
        {
            if (ModelState.IsValid)
            {
                if (_cRUDLibrary.EditLibRecord(cRUDLibraryModel))
                {
                    TempData["EditLibraryRecord"] = "Successfully Edited";
                }
            }
            return RedirectToAction("GetList");
        }
        public ActionResult Details(int id)
        {
            return View(_cRUDLibrary.LibDetails(id));
        }
        public ActionResult Delete(int id)
        {
            if (_cRUDLibrary.DeleteLibRecord(id))
            {
                TempData["DeleteLibrary"] = "Successfully Deleted";
            }
            return RedirectToAction("GetList");
        }
        public ActionResult Find()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Find(String Search_)
        {
            int id = _cRUDLibrary.FindOrSearch(Search_);
            if (id > 0)
            {
                return RedirectToAction("Details", new { id = id });
            }
            else
            {
                ViewBag.Message = "Enter Correct Details";
                return View();
            }

        }


        //..................................................

        public ActionResult About_()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact_()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}