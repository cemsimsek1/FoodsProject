using FoodsProject.Data.Models;
using FoodsProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace FoodsProject.Controllers
{
    public class CategoryController : Controller
    {
        Context c = new Context();
        CategoryRepository categoryRepository = new CategoryRepository();
        public IActionResult Index()
        {
            return View(categoryRepository.TList());
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddCategory");
            }
            else
            {
                var add = c.Categories.Where(x => x.CategoryName == p.CategoryName && x.CategoryDescription == p.CategoryDescription).FirstOrDefault();

                if (add == null)
                {
                    categoryRepository.TAdd(p);
                }
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult FindCategory(int id)
        {
            return View(c.Categories.Find(id));
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            return View(c.Categories.Find(id));
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category ct)
        {
            var up = c.Categories.Find(ct.CategoryID);

            if (up != null)
            {
                up.CategoryName = ct.CategoryName;
                up.CategoryDescription = ct.CategoryDescription;
                up.CategoryStatus = true;
                categoryRepository.TUpdate(ct);
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            var x = categoryRepository.TGet(id);

            if (x != null)
            {
                x.CategoryStatus = false;
                categoryRepository.TUpdate(x);
            }

            return RedirectToAction("Index");
        }
    }
}
