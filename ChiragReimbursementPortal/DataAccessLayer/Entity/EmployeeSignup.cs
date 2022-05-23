using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
  public class EmployeeSignup
    {
        [Required(ErrorMessage = "Please enter your Email Address")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please provide a valid Email Address")]
        [Column(TypeName = "varchar(25)")]
        public string  Email { get; set; }


        [Required(ErrorMessage = "Please enter your Password")]
        [Display(Name = "Password")]
        [Compare("confirmPassword", ErrorMessage = "Password does not match")]
        [DataType(DataType.Password, ErrorMessage = "Please Provide a valid Password")]
        [Column(TypeName = "varchar(25)")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password, ErrorMessage = "Password does not match")]
        [Column(TypeName = "varchar(25)")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter your username")]
        [Display(Name = "Full Name")]
        [Column(TypeName = "varchar(25)")]
     
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Please enter your Pan number")]
        [Display(Name = "Pan number")]
        [Column(TypeName = "varchar(25)")]
      
        public string PanNumber { get; set; }

        [Required(ErrorMessage = "Please enter your Bank")]
        [Display(Name = "Bank")]
        [Column(TypeName = "varchar(25)")]
        public string Bank { get; set; }

        [Required(ErrorMessage = "Please enter your Bank Account number")]
        [Display(Name = "Bank Account number")]
        [Column(TypeName = "varchar(25)")]
       /* [Range(0, Int64.MaxValue, ErrorMessage = "Account Number should not contain numbers characters")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Account number should have minimum 12 digits")]
        [MinLength(12, ErrorMessage = "Account number should have Max 12 digits")]*/
        public string BankAccountNumber { get; set; }

        [Column(TypeName = "varchar(5)")]
        public string isApprover { get; set; }
    }
}
