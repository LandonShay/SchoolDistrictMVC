using Microsoft.AspNet.Identity;
using SchoolDistrictMVC.Models.School;
using SchoolDistrictMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolDistrictMVC.Controllers
{
    public class SchoolController : Controller
    {
        public ActionResult Index()
        {
            var service = CreateSchoolService();
            var model = service.GetSchoolsList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SchoolCreate school)
        {
            if (!ModelState.IsValid) return View(school);

            var service = CreateSchoolService();

            if (service.CreateSchool(school))
            {
                TempData["SaveResult"] = $"{school.Name} was successfully created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", $"{school.Name} could not be created.");

            return View(school);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSchoolService();
            var model = svc.GetSchoolById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateSchoolService();
            var detail = service.GetSchoolById(id);
            var model = new SchoolEdit
            {
                SchoolId = detail.SchoolId,
                Name = detail.Name,
                Address = detail.Address,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SchoolEdit school)
        {
            if (!ModelState.IsValid) return View(school);

            if (school.SchoolId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(school);
            }

            var service = CreateSchoolService();

            if (service.UpdateSchool(school))
            {
                TempData["SaveResult"] = $"{school.Name} was successfully updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", $"{school.Name} could not be updated.");
            return View();
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateSchoolService();
            var model = svc.GetSchoolById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSchool(int id)
        {
            var service = CreateSchoolService();

            service.DeleteSchool(id);

            TempData["SaveResult"] = "The school was successfully deleted";

            return RedirectToAction("Index");
        }

        private SchoolService CreateSchoolService()
        {
            var service = new SchoolService();
            return service;
        }
    }
}