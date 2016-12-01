using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SandwichSwap.ViewModels
{
	public class PartialMenuViewModel
	{
		public string username { get; set; }
		public string sandwichname { get; set; }
		public List<Sandwich_Topping> Toppings { get; set; }
		public Bread Bread { get; set; }

		public PartialMenuViewModel(string username, string sandwichname, List<Sandwich_Topping> toppings, Bread b)
		{
			this.username = username;
			this.sandwichname = sandwichname;
			this.Toppings = toppings;
			Bread = b;
		}
	}
}