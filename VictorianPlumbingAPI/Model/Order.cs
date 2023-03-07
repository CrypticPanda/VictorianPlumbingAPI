using System;
using System.Collections.Generic;

namespace VictorianPlumbingAPI.Model
{
    public class Order
    {
        public Order()
        {
        }

        public Guid Id { get; set; }

        public decimal TotalPaid { get; set; }

        public Customer Customer { get; set; }

        public IList<OrderItem> OrderItems { get; set; }
    }
}
