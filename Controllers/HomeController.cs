using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalTestStevesBlind.Models;

namespace TechnicalTestStevesBlind.Controllers
{
    public class HomeController : Controller
    {
        private readonly TechnicalTestContext _context;
        public HomeController(TechnicalTestContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var infoList = _context.Person.ToList();
            return View(infoList);
        }

        //public IActionResult Add()
        //{
        //    return View();
        //}
        [HttpPost]
        public IActionResult Add(Person newPerson)
        {

            if (ModelState.IsValid)
            {
                _context.Add(newPerson);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit()
        {
            var update = _context.Person.ToList();
            //if (Id != person.Id)
            //{
            //    return BadRequest();
            //}
            //_context.Entry(person).State = EntityState.Modified;
            //_context.SaveChanges();
            //return View("Index");
            if (update != null)
            {
                List<Person> person = new List<Person>();

                foreach (var item in person)
                {
                    var act = _context.Person.First(a => a.Id == item.Id);
                    if (act != null)
                    {
                        person.Add(act);
                    }
                }
                return View(person);
            }
            else
            {
                return View("Index");
            }
        }
        [HttpPost]
        public IActionResult Edit(Person person)
        {
            if (person.Id != null)
            {
                var found = _context.Person.Find(person.Id);
                if (ModelState.IsValid)
                {
                    found.Name = person.Name;
                    found.Dob = person.Dob;
                    found.Gender = person.Gender;
                    found.Country = person.Country;
                    found.State = person.State;
                    _context.Entry(found).State = EntityState.Modified;
                    _context.Update(found);
                    _context.SaveChanges();
                }
            }
            //var found = _context.Person.Find(person.Id);
            //if (ModelState.IsValid && found != null)
            //{

            //    _context.Entry(found).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //    _context.Update(found);
            //    _context.SaveChanges();
            //}
            return RedirectToAction("Edit");

        }
        public IActionResult Delete(int Id)
        {
            var delete = _context.Person.Find(Id);
            
            if (ModelState.IsValid)
            {
                _context.Person.Remove(delete);
                _context.SaveChanges();
            }
           
            return RedirectToAction("Index");
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
