using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SandwichSwap
{
    public class OrderModel
    {
        public User user { get; set; }
        public Card card { get; set; }
        public Sandwich sandwich { get; set; }
    }
}