using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using demoMVCCore.Models;
using demoMVCCore.Models.Data;
using ReflectionIT.Mvc.Paging;
using Microsoft.EntityFrameworkCore;


namespace demoMVCCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppdbContext _context;

        public HomeController(AppdbContext context) {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index(int page =1)
          
        {
            //var emp = _context.Employees.ToList();
            var query = _context.Employees.AsNoTracking().OrderBy(e => e.LastName);
            var emp = PagingList.Create(query, 5, page);
            return View(emp);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (!ModelState.IsValid) return View(emp);
            _context.Add(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = _context.Employees.Find(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            if (!ModelState.IsValid) return View(emp);
            _context.Employees.Update(emp);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var emp = _context.Employees.Find(id);
            _context.Employees.Remove(emp);
            _context.SaveChanges();
            return RedirectToAction("index");
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
