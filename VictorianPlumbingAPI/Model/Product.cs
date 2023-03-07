using System;
using System.ComponentModel.DataAnnotations;

namespace VictorianPlumbingAPI.Model
{
    public class Product
    {
        public Product()
        {
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
    }
}
