using System;
using System.ComponentModel.DataAnnotations;

namespace VictorianPlumbingAPI.Model
{
    public class OrderItem
    {
        public OrderItem()
        {
        }

        public Guid Id { get; set; }

        public Product Product { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
    }
}
