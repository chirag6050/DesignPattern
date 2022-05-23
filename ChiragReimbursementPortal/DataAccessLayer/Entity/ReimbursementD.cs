using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    public class ReimbursementD
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        [Required]
        [Display(Name = "Reimburement Type")]
        [Column(TypeName = "varchar(25)")]
        public string ReimburementType { get; set; }

        [Required]
        [Display(Name = "Requested Value")]
        [Column(TypeName = "varchar(10)")]
        public string RequestedValue { get; set; }

        // [Required]
        [Display(Name = "Approved Value")]
        [Column(TypeName = "varchar(10)")]
        public string ApprovedValue { get; set; }

        [Required]
        [Display(Name = "Currency")]
        [Column(TypeName = "varchar(10)")]
        public string Currency { get; set; }


        //[Required]
        [Display(Name = "Requested Phase")]
        [Column(TypeName = "varchar(25)")]
        public string RequestedPhase { get; set; }

        //[Required]
        [Display(Name = "Receipt")]
        [Column(TypeName = "varchar(5)")]
        public string Receipt { get; set; }

        
    }
}
