using BTH_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BTH_2.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> listStudents = new List<Student>();

        public StudentController()
        {
            listStudents = new List<Student>()
            {
                new Student()
                {
                    Id = 101, Name = "Hải Nam", Branch = Branch.IT, Gender = Gender.Male,
                    IsRegular = true, Address = "A1-2018", Email = "nam@g.com"
                },
                new Student()
                {
                    Id = 102, Name = "Minh Tú", Branch = Branch.BE, Gender = Gender.Female,
                    IsRegular = true, Address = "A1-2019", Email = "tu@g.com"
                },
                new Student()
                {
                    Id = 103, Name = "Hoàng Phong", Branch = Branch.CE, Gender = Gender.Male,
                    IsRegular = true, Address = "A1-2020", Email = "phong@g.com"
                },
                new Student()
                {
                    Id = 104, Name = "Xuân Mai", Branch = Branch.EE, Gender = Gender.Female,
                    IsRegular = true, Address = "A1-2021", Email = "mai@g.com"
                }
            };
        }

        // GET
        public IActionResult Index()
        {
            return View(listStudents);
        }
        
        [HttpGet("Add")]
        public IActionResult Create() {
            this.ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

            this.ViewBag.AllBranches = new List<SelectListItem>() {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "BE", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" },
            };

            return this.View();
        }

        [HttpPost("Add")]
        public IActionResult Create(Student s) {
            s.Id = listStudents.Last<Student>().Id + 1;

            StudentController.listStudents.Add(s);

            return this.View("Index", StudentController.listStudents);
        }
       
    }
}
    