using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VictorianPlumbingAPI.Model
{
    public class Customer
    {
        public Customer()
        {
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email needs to be in correct format")]
        public string Email { get; set; }
    }
}
