using SchoolDistrictMVC.Data;
using SchoolDistrictMVC.Models;
using SchoolDistrictMVC.Models.Student;
using SchoolDistrictMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolDistrictMVC.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Index(string sortOrder, int page = 1)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var service = CreateStudentService();
                var model = service.GetStudentList();

                int itemsPerPage = 10;

                int start = (page - 1) * itemsPerPage;

                var items = model;
                ViewBag.PageCount = Math.Ceiling(items.Count() / (double)itemsPerPage);

                ViewBag.IDSort = string.IsNullOrEmpty(sortOrder) ? "idDescending" : "";
                ViewBag.NameSort = sortOrder == "name" ? "nameDescending" : "name";
                ViewBag.DateSort = sortOrder == "date" ? "dateDescending" : "date";
                ViewBag.SchoolSort = sortOrder == "school" ? "schoolDescending" : "school";

                var students = from s in model select s;

                switch (sortOrder)
                {
                    case "name":
                        students = students.OrderBy(s => s.Name);
                        break;
                    case "nameDescending":
                        students = students.OrderByDescending(s => s.Name);
                        break;
                    case "date":
                        students = students.OrderBy(s => s.DateOfBirth);
                        break;
                    case "dateDescending":
                        students = students.OrderByDescending(s => s.DateOfBirth);
                        break;
                    case "school":
                        students = students.OrderBy(s => s.School);
                        break;
                    case "schoolDescending":
                        students = students.OrderByDescending(s => s.School);
                        break;
                    case "idDescending":
                        students = students.OrderByDescending(s => s.Id);
                        break;
                    default:
                        students = students.OrderBy(s => s.Id);
                        break;
                }

            return View(students.ToList().Skip(start).Take(itemsPerPage));
            }
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
        public ActionResult Create(StudentCreate student)
        {
            if (!ModelState.IsValid) return View(student);

            var service = CreateStudentService();

            if (service.CreateStudent(student))
            {
                TempData["SaveResult"] = $"{student.FirstName} {student.LastName} was successfully created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", $"{student.FirstName} {student.LastName} could not be created.");

            return View(student);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateStudentService();
            var model = svc.GetStudentById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateStudentService();
            var detail = service.GetStudentById(id);
            var model = new StudentEdit
            {
                Id = detail.Id,
                FirstName = detail.FirstName,
                LastName = detail.LastName,
                DateOfBirth = detail.DateOfBirth,
                Grade = detail.Grade,
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
        public ActionResult Edit(int id, StudentEdit student)
        {
            if (!ModelState.IsValid) return View(student);

            if (student.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(student);
            }

            var service = CreateStudentService();

            if (service.UpdateStudent(student))
            {
                TempData["SaveResult"] = $"{student.FirstName} {student.LastName} was successfully updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", $"{student.FirstName} {student.LastName} could not be updated.");
            return View();
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateStudentService();
            var model = svc.GetStudentById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteStudent(int id)
        {
            var service = CreateStudentService();

            service.DeleteStudent(id);

            TempData["SaveResult"] = "The student was successfully deleted";

            return RedirectToAction("Index");
        }

        private StudentService CreateStudentService()
        {
            var service = new StudentService();
            return service;
        }
    }
}