using SandwichSwap.ViewModels;
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
		
        public ActionResult Register()
        {
            return View();
        }
		[HttpPost]
		public ActionResult Register(User user)
		{
			using (sandwichswapContext con = new sandwichswapContext())
			{
				con.Users.Add(user);
				con.SaveChanges();
			}
			return View("Index");
		}
		public ActionResult UserProf()
        {
            return View();
        }
        public ActionResult Menu()
        {
			List<Bread> breads = new List<Bread>();
			List<Topping> toppings = new List<Topping>();
			using (sandwichswapContext con = new sandwichswapContext())
			{
				breads = con.Breads.ToList();
				toppings = con.Toppings.ToList();
			}
			return View(new MenuViewModel(breads, toppings));
		}
        public ActionResult Order()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Order(OrderViewModel order)
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

        public PartialViewResult AddRow(MenuViewModel model)
		{
			numOfRows++;
			model.Rows = numOfRows;
			return PartialView("_ToppingTablePartialView", model);
		}

		public void SaveSandwich(int breadId, int[] toppingIds/*, string userName, string sandwichName*/)
		{
			
			using (sandwichswapContext con = new sandwichswapContext())
			{
				Sandwich s = new Sandwich();
				//s.Id = 1;
				//s.BreadId = breadId;
				s.Bread = con.Breads.Where(x => x.Id == breadId).Single();
				//s.Toppings = con.Toppings.Where(x => toppingIds.Contains(x.Id)).ToList();
                foreach(int topid in toppingIds)
                {
                    //Topping topping = con.Toppings.Where(x => x.Id == topid).Single();
                    Sandwich_Topping newtopping = new Sandwich_Topping();
                    newtopping.Sandwich = s;
                    newtopping.ToppingId = topid;
                    s.Sandwich_Topping.Add(newtopping);
                }

				s.User = con.Users.Where(x => x.username.Equals("rstead")).Single();
				//s.username = "rstead";
				s.sandwichname = "DEFAULT NAME";
				s.votes = 0;
				con.Sandwiches.Add(s);
				con.SaveChanges();
                
                
            }
		}
    }
}