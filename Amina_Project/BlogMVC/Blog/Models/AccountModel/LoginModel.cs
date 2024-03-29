﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Blog.Models.AccountModel
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
        public string? ConfirmPassword { get; set; }
    }
}
