// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CC_Sports.Models
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("UserID")]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "User Name")]
        public string UserLogin { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Password")]
        [UIHint("password")]
        public string UserPassword { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "First name must consist of upper or lower case letters only")]        
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Last name must consist of upper or lower case letters only")]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        [RegularExpression(@"^[A-Za-z0-9 _]*[A-Za-z0-9][A-Za-z0-9 _]*$", ErrorMessage = "Street Address must consist of upper case, lower case, and/or numbers only")]
        public string StreetAddress { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "City must consist of upper or lower case letters only")]
        public string City { get; set; }

        [Required]
        [StringLength(2)]
        [RegularExpression(@"^(?:A[KLRZ]|C[AOT]|D[CE]|FL|GA|HI|I[ADLN]|K[SY]|LA|M[ADEINOST]|N[CDEHJMVY]|O[HKR]|PA|RI|S[CD]|T[NX]|UT|V[AT]|W[AIVY])*$", ErrorMessage = "State must consist of upper case letters only using two code format")]
        public string State { get; set; }

        [Required]
        [StringLength(10)]
        [RegularExpression(@"^[0-9\-]+$", ErrorMessage = "ZIP Code must consist of numbers and dashes only")]
        public string Zip { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }


        [InverseProperty(nameof(Order.User))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}