using System;
using System.Collections.Generic;

namespace BartenderAppReview.Models
{
    public partial class Drink
    {
        public Drink()
        {
            Order = new HashSet<Order>();
        }

        public int DrinkId { get; set; }
        public string DrinkName { get; set; }
        public int DrinkPrice { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
