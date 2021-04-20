using DevDe.UI.AppModel.Data;
using DevDe.UI.AppModel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevDe.UI.AppModel.Controllers
{
    public class TestCrud : Controller
    {
        private readonly MyDbContext _context;

        public TestCrud(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var student = new Student
            {
                Name = "Esdras",
                BirthDate = DateTime.Now,
                Email = "esdrasteste@teste.com.br"
            };

            // Insert
            // in this moment, the data are saved in memory '_context'
            _context.Students.Add(student);
            // now, the data are saved in Database
            _context.SaveChanges();

            //// find for student by Id
            //var student2 = _context.Students.Find(student.Id);
            //// find for student by email
            //var student3 = _context.Students.FirstOrDefault(a => a.Email == "esdrasteste@teste.com.br");
            ////find for a collection students
            //var student4 = _context.Students.Where(a => a.Name == "Esdras");

            //// Update
            //student.Name = "Pedro";
            //_context.Students.Update(student);
            //_context.SaveChanges();

            //// Delete
            //_context.Students.Remove(student);
            //_context.SaveChanges();


            return View("_Layout");
        }
    }
}
