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
        public static User LoginUser=null;
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
        [HttpPost]
        public ActionResult Login(LoginViewModel viewm)
        {
            bool valid = false;
            using (sandwichswapContext con = new sandwichswapContext())
            {
                foreach(User u in con.Users)
                {
                    if (u.username == viewm.Username)
                    {
                        if (u.password == viewm.Password)
                        {
                            valid = true;
                            LoginUser = u;
                        }
                    }
                }
            }
            ActionResult r=null;
            if (valid)
            {
                r = View("Index");
            }
            else
            {
                ModelState.AddModelError("Password","Invald Password");               
                r = View();
            }
            return r;
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
			List<Sandwich> sandwiches = new List<Sandwich>();
			List<PartialMenuViewModel> pms = new List<PartialMenuViewModel>();
			using (sandwichswapContext con = new sandwichswapContext())
			{
				breads = con.Breads.ToList();
				toppings = con.Toppings.ToList();
				sandwiches = con.Sandwiches.ToList();
				foreach(Sandwich s in sandwiches)
				{
					pms.Add(new PartialMenuViewModel(s.username, s.sandwichname, s.Sandwich_Topping.ToList(), s.Bread));
				}
			}
			return View(new MenuViewModel(breads, toppings, sandwiches, pms));
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
				s.Bread = con.Breads.Where(x => x.Id == breadId).Single();
                for(int i = 1; i < toppingIds.Count(); i++)
                {
                    Sandwich_Topping newtopping = new Sandwich_Topping();
                    newtopping.Sandwich = s;
                    newtopping.ToppingId = toppingIds[i];
                    s.Sandwich_Topping.Add(newtopping);
                }

				s.User = con.Users.Where(x => x.username.Equals(LoginUser)).Single();
				s.sandwichname = "DEFAULT NAME";
				s.votes = 0;
				con.Sandwiches.Add(s);
				con.SaveChanges();
                
                
            }
		}
    }
}