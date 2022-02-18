using SchoolDistrictMVC.Data;
using SchoolDistrictMVC.Models;
using SchoolDistrictMVC.Models.Class;
using SchoolDistrictMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolDistrictMVC.Controllers
{
    public class ClassController : Controller
    {
        public ActionResult Index()
        {
            var service = CreateClassService();
            var model = service.GetClassList();
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

            List<Teacher> Teachers = new TeacherService().GetTeachers().ToList();

            var query2 = from s in Teachers
                         select new SelectListItem()
                         {
                             Value = s.Id.ToString(),
                             Text = s.FullName,
                         };

            ViewBag.SchoolId = query.ToList();
            ViewBag.TeacherId = query2.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClassCreate c)
        {
            if (!ModelState.IsValid) return View(c);

            var service = CreateClassService();

            if (service.CreateClass(c))
            {
                TempData["SaveResult"] = $"{c.Name} was successfully created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", $"{c.Name} could not be created.");

            return View(c);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateClassService();
            var model = svc.GetClassById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateClassService();
            var detail = service.GetClassById(id);
            var model = new ClassEdit
            {
                Id = detail.Id,
                Name = detail.Name,
                Subject = detail.Subject,
            };
            List<School> Schools = new SchoolService().GetSchools().ToList();

            var query = from s in Schools
                        select new SelectListItem()
                        {
                            Value = s.Id.ToString(),
                            Text = s.Name,
                        };

            List<Teacher> Teachers = new TeacherService().GetTeachers().ToList();

            var query2 = from s in Teachers
                         select new SelectListItem()
                         {
                             Value = s.Id.ToString(),
                             Text = s.FullName,
                         };

            ViewBag.SchoolId = query.ToList();
            ViewBag.TeacherId = query2.ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClassEdit c)
        {
            if (!ModelState.IsValid) return View(c);

            if (c.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(c);
            }

            var service = CreateClassService();

            if (service.UpdateClass(c))
            {
                TempData["SaveResult"] = $"{c.Name} was successfully updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", $"{c.Name} could not be updated.");
            return View();
        }

        public ActionResult ViewClassRoster(ClassRoster c)
        {
            var svc = CreateClassService();
            var model = svc.GetClassLineup(c);

            ViewBag.Class = $"{c.Name}";
            ViewBag.Teacher = $"{c.Teacher}";

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateClassService();
            var model = svc.GetClassById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteClass(int id)
        {
            var service = CreateClassService();

            service.DeleteClass(id);

            TempData["SaveResult"] = "The class was successfully deleted";

            return RedirectToAction("Index");
        }

        private ClassService CreateClassService()
        {
            var service = new ClassService();
            return service;
        }
    }
}