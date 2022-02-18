using Microsoft.AspNet.Identity;
using SchoolDistrictMVC.Data;
using SchoolDistrictMVC.Models.Teacher;
using SchoolDistrictMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolDistrictMVC.Controllers
{
    public class TeacherController : Controller
    {
        public ActionResult Index()
        {
            var service = CreateTeacherService();
            var model = service.GetTeacherList();
            return View(model);
        }

        public ActionResult Create()
        {
            List<School> Schools = new SchoolService().GetSchools().ToList();

            var query = from s in Schools
                        select new SelectListItem()
                        {
                            Value = s.Id.ToString(),
                            Text = s.Name,
                        };

            ViewBag.SchoolId = query.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeacherCreate teacher)
        {
            if (!ModelState.IsValid) return View(teacher);

            var service = CreateTeacherService();

            if (service.CreateTeacher(teacher))
            {
                TempData["SaveResult"] = $"{teacher.FirstName} {teacher.LastName} was successfully created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", $"{teacher.FirstName} {teacher.LastName} could not be created.");

            return View(teacher);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateTeacherService();
            var model = svc.GetTeacherById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTeacherService();
            var detail = service.GetTeacherById(id);
            var model = new TeacherEdit
            {
                Id = detail.Id,
                FirstName = detail.FirstName,
                LastName = detail.LastName,
                DateOfBirth = detail.DateOfBirth,
            };

            List<School> Schools = new SchoolService().GetSchools().ToList();

            var query = from s in Schools
                        select new SelectListItem()
                        {
                            Value = s.Id.ToString(),
                            Text = s.Name,
                        };

            ViewBag.SchoolId = query.ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TeacherEdit teacher)
        {
            if (!ModelState.IsValid) return View(teacher);

            if (teacher.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(teacher);
            }

            var service = CreateTeacherService();

            if (service.UpdateTeacher(teacher))
            {
                TempData["SaveResult"] = $"{teacher.FirstName} {teacher.LastName} was successfully updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", $"{teacher.FirstName} {teacher.LastName} could not be updated.");
            return View();
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateTeacherService();
            var model = svc.GetTeacherById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTeacher(int id)
        {
            var service = CreateTeacherService();

            service.DeleteTeacher(id);

            TempData["SaveResult"] = "The teacher was successfully deleted";

            return RedirectToAction("Index");
        }

        private TeacherService CreateTeacherService()
        {
            var service = new TeacherService();
            return service;
        }
    }
}