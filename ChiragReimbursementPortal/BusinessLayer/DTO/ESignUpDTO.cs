using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class ESignUpDTO
    {
        [Required(ErrorMessage = "Email Required!")]
        [Display(Name = "Enter Email")]
        [Column(TypeName = "varchar(30)")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required!")]
        [Display(Name = "Enter Password")]
        [Column(TypeName = "varchar(30)")]
        [DataType(DataType.Password, ErrorMessage = "Invalid Password Address")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ReEnter Password Required!")]
        [Display(Name = "ReEnter Password")]
        [Column(TypeName = "varchar(30)")]
        [DataType(DataType.Password, ErrorMessage = "Invalid ReEnter Password Address")]
        public string ReEnterPassword { get; set; }

        [Required(ErrorMessage = "Full Name Required!")]
        [Display(Name = "Full Name")]
        [Column(TypeName = "varchar(30)")]
        [StringLength(50, ErrorMessage = " Maximum character can be 25")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabets allowed")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "PAN Number Required!")]
        [Display(Name = "PAN Number")]
        [Column(TypeName = "varchar(10)")]
        [MaxLength(10, ErrorMessage = " Maximum character can be 10")]
        [MinLength(10, ErrorMessage = "Enter Correct Pan Number")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Only Alphabets and Numbers allowed")]
        public string PanNumber { get; set; }

        [Required(ErrorMessage = "Bank Name Required!")]
        [Display(Name = "Bank Name")]
        [Column(TypeName = "varchar(25)")]
        public string Bank { get; set; }

        [Required(ErrorMessage = "Account Number Required!")]
        [Display(Name = "Account Number")]
        [Column(TypeName = "varchar(15)")]
        [Range(0, Int64.MaxValue, ErrorMessage = "Account Number should not contain numbers characters")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Account number should have minimum 12 digits")]
        [MinLength(12, ErrorMessage = "Account number should have Max 12 digits")]
        public string AccountNumber { get; set; }

        [Column(TypeName = "varchar(5)")]
        public string isApprover { get; set; }
    }
}
