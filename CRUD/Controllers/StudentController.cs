using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class StudentController : Controller
    {

        private readonly CollegeDbContext _collegeDbContext;
        
        public StudentController(CollegeDbContext collegeDbContext)
        {
            _collegeDbContext = collegeDbContext;
        }
        public IActionResult Index()
        {
            List<StudentModel> model = _collegeDbContext.Students.ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentModel model)
        {
            if (model != null)
            {
                _collegeDbContext.Students.Add(model);
                _collegeDbContext.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            StudentModel model = _collegeDbContext.Students.FirstOrDefault(x => x.Id == id);
            if (model == null)
            {
                model = new StudentModel();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(StudentModel model)
        {
            _collegeDbContext.Students.Update(model);
            _collegeDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(int id)
        {
            StudentModel model = _collegeDbContext.Students.FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                _collegeDbContext.Students.Remove(model);
                _collegeDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit");
                

        }



    }
}
