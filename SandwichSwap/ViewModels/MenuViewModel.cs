using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SandwichSwap.ViewModels
{
	public class MenuViewModel
	{

		private User _sandwichUser;

		public MenuViewModel(List<Bread> breads, List<Topping> toppings)
		{
			Breads = breads;
			Toppings = toppings;
			Rows = 3;
		}
			
		public List<Bread> Breads{ get; set; }

		public List<Topping> Toppings { get; set; }

		public int Rows { get; set; }

	}
}