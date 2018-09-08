using System;
using System.Collections.Generic;

namespace BartenderAppReview.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int DrinkId { get; set; }
        public string CustomerName { get; set; }
        public string DrinkName { get; set; }

        public Drink Drink { get; set; }
    }
}
