using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;

namespace _20_09_23_MvcLoginAndRegistration.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid email.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}