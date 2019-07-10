﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Order
    {

        public int OrderId { get; set; }
        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]

        [Display(Name = "Last Name")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your address")]

        [Display(Name = "Addres Line 1")]


        public string Addres1 { get; set; }
        [Display(Name = "Addres Line 2")]

        public string Addres2 { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]

        [Display(Name = "Phone Number")]


        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; }
        public double OrderTotal { get; set; }
        public DateTime OrderTime { get; set; }


        public IEnumerable<OrderDetail> OrderLines { get; set; }
    }
}
