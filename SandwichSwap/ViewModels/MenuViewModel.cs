using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SandwichSwap.ViewModels
{
    public class MenuViewModel
    {

        private User _sandwichUser;

		public List<Sandwich> Sandwiches { get; set; }

		public List<PartialMenuViewModel> PMViewModel { get; set; }

		public MenuViewModel(List<Bread> breads, List<Topping> toppings, List<Sandwich> sandwiches, List<PartialMenuViewModel> pm)
        {
            Breads = breads;
            Toppings = toppings;
			Sandwiches = sandwiches;
            Rows = 3;
			PMViewModel = pm;
        }

        public List<Bread> Breads { get; set; }

        public List<Topping> Toppings { get; set; }

        public int Rows { get; set; }

    }
}