using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(IStudentRepository studentRepository,
                               IHostingEnvironment hostingEnvironment)
        {
            _studentRepository = studentRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        public ViewResult Index()
        {
            var model = _studentRepository.GetAllStudents();
            return View(model);
        }

        
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Student = _studentRepository.GetStudent(id??1),
                PageTitle = "Student Details"
            };
            
            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(model.Photo != null)
                {
                   string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                   uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Student newStudent = new Student
                {
                    Name = model.Name,
                    Email = model.Email,
                    Course = model.Course,
                    PhotoPath = uniqueFileName
                
                };
                    
                _studentRepository.Add(newStudent);
                return RedirectToAction("details", new { id = newStudent.Id });
            }
            return View();
        }
    }
}
