using Edmsoft.DataAccessLayer;
using Edmsoft.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edmsoft.Controllers
{
    public class StudentController : Controller
    {
        StudentDataAccessLayer studentDataAccessLayer = null;

        public StudentController()
        {
            studentDataAccessLayer = new StudentDataAccessLayer();
        }

        public ActionResult Index()
        {
            IEnumerable<StudentGrade> students = studentDataAccessLayer.GetAllStudent();
            return View(students);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            StudentGrade student = studentDataAccessLayer.GetStudentData(id);
            return View(student);
        }

        public ActionResult Edit(int id)
        {
            StudentGrade student = studentDataAccessLayer.GetStudentData(id);
            return View(student);
        }


        [HttpPost]
        public ActionResult Create(StudentGrade student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    studentDataAccessLayer.AddStudent(student);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("Home", student);
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(StudentGrade student)
        {
            try
            {
                studentDataAccessLayer.UpdateStudent(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            StudentGrade student = studentDataAccessLayer.GetStudentData(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(StudentGrade student)
        {
            try
            {
                studentDataAccessLayer.DeleteStudent(student.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
