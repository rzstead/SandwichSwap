﻿using SandwichSwap.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SandwichSwap.Controllers
{
    public class HomeController : Controller
    {
		private static int numOfRows = 3;
		// GET: Home
		public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult UserProf()
        {
            return View();
        }
        public ActionResult CreateSandwich()
        {
			List<Bread> breads = new List<Bread>();
			List<Topping> toppings = new List<Topping>();
			using(sandwichswapContext con = new sandwichswapContext())
			{
				breads = con.Breads.ToList();
				toppings = con.Toppings.ToList();
			}
            return View(new CreateSandwichViewModel(breads, toppings));
        }
        public ActionResult Menu()
        {
            return View();
        }
        public ActionResult Order()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Order(OrderModel order)
        {
            ActionResult result;
            if (ModelState.IsValid)
            {
                result = View(order);
            }
            else
            {
                result = View();
            }
            return result;

        }

        public PartialViewResult AddRow(CreateSandwichViewModel model)
		{
			numOfRows++;
			model.Rows = numOfRows;
			return PartialView("_ToppingTablePartialView", model);
		}
    }
}