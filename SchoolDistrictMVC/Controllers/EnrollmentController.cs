using SchoolDistrictMVC.Data;
using SchoolDistrictMVC.Models.Enrollment;
using SchoolDistrictMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolDistrictMVC.Controllers
{
    public class EnrollmentController : Controller
    {
        public ActionResult Index()
        {
            var service = CreateEnrollmentService();
            var model = service.GetEnrollmentList();
            return View(model);
        }

        public ActionResult Create()
        {
            List<Student> Students = new StudentService().GetStudents().ToList();

            var query = from s in Students
                        select new SelectListItem()
                        {
                            Value = s.Id.ToString(),
                            Text = s.FullName,
                        };

            List<Class> Classes = new ClassService().GetClasses().ToList();

            var query2 = from s in Classes
                        select new SelectListItem()
                        {
                            Value = s.Id.ToString(),
                            Text = s.Name,
                        };

            ViewBag.StudentId = query.ToList();
            ViewBag.ClassId = query2.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EnrollmentCreate student)
        {
            if (!ModelState.IsValid) return View(student);

            var service = CreateEnrollmentService();

            if (service.CreateEnrollment(student))
            {
                TempData["SaveResult"] = $"Assignment successful.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", $"Assignment unsuccessful");
            return View(student);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateEnrollmentService();
            var model = svc.GetEnrollmentById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateEnrollmentService();
            var detail = service.GetEnrollmentById(id);
            var model = new EnrollmentEdit
            {
                Id = detail.Id,
                StudentId = detail.StudentId,
                ClassId = detail.ClassId,
            };

            List<Student> Students = new StudentService().GetStudents().ToList();

            var query = from s in Students
                        select new SelectListItem()
                        {
                            Value = s.Id.ToString(),
                            Text = s.FullName,
                        };

            List<Class> Classes = new ClassService().GetClasses().ToList();

            var query2 = from s in Classes
                         select new SelectListItem()
                         {
                             Value = s.Id.ToString(),
                             Text = s.Name,
                         };

            ViewBag.StudentId = query.ToList();
            ViewBag.ClassId = query2.ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EnrollmentEdit student)
        {
            if (!ModelState.IsValid) return View(student);

            if (student.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(student);
            }

            var service = CreateEnrollmentService();

            if (service.UpdateEnrollment(student))
            {
                TempData["SaveResult"] = $"Enrollment updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", $"Update failed.");
            return View();
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateEnrollmentService();
            var model = svc.GetEnrollmentById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEnrollment(int id)
        {
            var service = CreateEnrollmentService();

            service.DeleteEnrollment(id);

            TempData["SaveResult"] = "The student was successfully deleted";

            return RedirectToAction("Index");
        }

        private EnrollmentService CreateEnrollmentService()
        {
            var service = new EnrollmentService();
            return service;
        }
    }
}