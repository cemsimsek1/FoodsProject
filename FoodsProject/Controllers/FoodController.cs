using FoodsProject.Data.Models;
using FoodsProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace FoodsProject.Controllers
{

    public class FoodController : Controller
    {

        FoodRepository foodRepository = new FoodRepository();
        Context c = new Context();
        public IActionResult Index(int page = 1)
        {
            return View(foodRepository.TList("Category").ToPagedList(page, 4));
        }
        [HttpGet]
        public IActionResult AddFood()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString(),
                                           }).ToList();

            ViewBag.Food = values;
            return View();
        }
        [HttpPost]
        public IActionResult AddFood(Food f)
        {
            foodRepository.TAdd(f);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFood(int id)
        {
            var delete = c.Foods.Find(id);

            if (delete != null)
            {
                foodRepository.TDelete(delete);
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult FindFood(int id)
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString(),
                                           }).ToList();

            return View(c.Foods.Find(id));
        }
        [HttpGet]
        public IActionResult UpdateFood(int id)
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString(),
                                           }).ToList();

            ViewBag.vls = values;

            return View(c.Foods.Find(id));
        }
        [HttpPost]
        public IActionResult UpdateFood(Food f)
        {
            var up = c.Foods.Find(f.FoodID);

            if (up != null)
            {
                up.FoodName = f.FoodName;
                up.FoodPrice = f.FoodPrice;
                up.FoodStock = f.FoodStock;
                up.CategoryID = f.CategoryID;

                foodRepository.TUpdate(up);
            }

            return RedirectToAction("Index");
        }
    }
}
