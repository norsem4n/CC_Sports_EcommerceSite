using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CC_Sports.Models
{
    public class LoginInput
    {
        [Key]
        [Required(ErrorMessage = "User name is required")]
        [MaxLength(100)]
        public string userName { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [UIHint("password")]
        [MaxLength(20)]
        public string userPassword { get; set; }

        public string ReturnURL { get; set; }

    }
}
