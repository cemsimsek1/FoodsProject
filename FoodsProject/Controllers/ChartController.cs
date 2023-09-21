using FoodsProject.Data;
using FoodsProject.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FoodsProject.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult VisualizeProductResult()
        {
            return Json(Prolist());
        }
        public List<Class1> Prolist()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                proname = "Computer",
                stock = 150
            });
            cs.Add(new Class1()
            {
                proname = "LCD",
                stock = 75
            });
            cs.Add(new Class1()
            {
                proname = "USB",
                stock = 220
            });

            return cs;
        }

        public IActionResult Statistics()
        {
            Context c = new Context();
            var x1 = c.Foods.Count();
            ViewBag.x1 = x1;

            var x2 = c.Categories.Count();
            ViewBag.x2 = x2;

            var x3 = c.Foods.Where(x => x.CategoryID == 1).Count();
            ViewBag.x3 = x3;

            var x4 = c.Foods.Where(x => x.CategoryID == 2).Count();
            ViewBag.x4 = x4;

            var x5 = c.Foods.Sum(x => x.FoodStock);
            ViewBag.x5 = x5;

            return View();
        }
    }
}
