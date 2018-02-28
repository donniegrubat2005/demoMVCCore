using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using demoMVCCore.Models;
using demoMVCCore.Models.Data;

namespace demoMVCCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppdbContext context;

        public HomeController(AppdbContext context) {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
          
        {
            var emp = context.Employees.ToList();
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
            context.Add(emp);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = context.Employees.Find(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            if (!ModelState.IsValid) return View(emp);
            context.Employees.Update(emp);
            context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var emp = context.Employees.Find(id);
            context.Employees.Remove(emp);
            context.SaveChanges();
            return RedirectToAction("index");
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
