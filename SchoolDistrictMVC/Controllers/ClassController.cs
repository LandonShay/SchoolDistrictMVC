using SchoolDistrictMVC.Data;
using SchoolDistrictMVC.Models;
using SchoolDistrictMVC.Models.Class;
using SchoolDistrictMVC.Models.Enrollment;
using SchoolDistrictMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
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

        [System.Web.Mvc.HttpPost]
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

        [System.Web.Mvc.HttpPost]
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

            string name = model.First().Name;
            string teacher = model.First().Teacher;

            ViewBag.Class = $"{name}";
            ViewBag.Teacher = $"{teacher}";

            return View(model);
        }

        public ActionResult AddToClassRoster()
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

        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToClassRoster(EnrollmentCreate enroll, [FromUri]int id)
        {
            if (!ModelState.IsValid) return View(enroll);

            var service = CreateEnrollmentService();

            if (service.CreateEnrollment(enroll, id))
            {
                TempData["SaveResult"] = $"Assignment successful.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", $"Assignment unsuccessful");
            return View(enroll);
        }

        public ActionResult RemoveFromClass(int id)
        {
            var svc = CreateEnrollmentService();
            var model = svc.GetEnrollmentById(id);

            return View(model);
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.ActionName("RemoveFromClass")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEnrollment(int id)
        {
            var service = CreateEnrollmentService();

            service.DeleteEnrollment(id);

            TempData["SaveResult"] = "The student was successfully removed from the class";

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateClassService();
            var model = svc.GetClassById(id);

            return View(model);
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.ActionName("Delete")]
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

        private EnrollmentService CreateEnrollmentService()
        {
            var service = new EnrollmentService();
            return service;
        }
    }
}