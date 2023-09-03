using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using E_commerce.Models;

namespace E_commerce.Data.ViewModels
{
    public class RegisterViewModel
    {
        [DisplayName( "Full name")]
        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; }

        [DisplayName ("Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName ("Confirm password")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
