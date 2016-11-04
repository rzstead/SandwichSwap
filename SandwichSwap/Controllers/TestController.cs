using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SandwichSwap.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            List<Test> users = new List<Test>();
            using (sandwichswapContext ssc = new sandwichswapContext())
            {
                users = ssc.Tests.ToList();
            }
                return View(users);
        }
    }
}