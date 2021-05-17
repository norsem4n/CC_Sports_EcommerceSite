using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//add namespace
using System.ComponentModel.DataAnnotations;

namespace CC_Sports.Models
{
    public class CartItem
    {
        public Product Product { get; set; }

        [Required(ErrorMessage = "Please enter quantity")]
        [Range(2, 20, ErrorMessage = "Please enter an amount between 1 and 20")]
        public int Quantity { get; set; }
    }
}
