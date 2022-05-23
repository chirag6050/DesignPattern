﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChiragReimbursementPortal.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email Required!")]
        [Display(Name = "Enter Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        public string EmailId { get; set; }


        [Required(ErrorMessage = "Password Required!")]
        [Display(Name = "Enter Password")]
        [DataType(DataType.Password, ErrorMessage = "Invalid Password Address")]
        public string password { get; set; }
    }
}
