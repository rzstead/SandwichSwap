using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SandwichSwap.ViewModels
{
    public class MenuViewModel
    {

        private User _sandwichUser;
        public List<Sandwich> sandwiches = new List<Sandwich>
        {
            new Sandwich
            {
                BreadId = 2, Toppings =
                {
                    new Topping
                    {
                        category = 1, Id = 1, imageURL = "none", name = "test", price = 0
                    },
                    new Topping
                    {
                        category = 2, Id = 2, imageURL = "none", name = "ugh", price = 1.50f
                    },
                    new Topping
                    {
                        category = 3, Id = 3, imageURL = "none", name = "please", price = 0
                    }
                },
                Id = 5, Bread = null, sandwichname = "The faquarshia", User = null, username = "Won't work", votes = 2
            }
        };

        public MenuViewModel(List<Bread> breads, List<Topping> toppings)
        {
            Breads = breads;
            Toppings = toppings;
            Rows = 3;
        }

        public List<Bread> Breads { get; set; }

        public List<Topping> Toppings { get; set; }

        public int Rows { get; set; }

    }
}