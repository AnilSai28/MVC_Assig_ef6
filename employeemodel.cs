using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace mvc_ef6_example.Models
{ 
    [Table("tbl_employees")]
    public class employeemodel
    {
        [Key]
        public string employeeemail { get; set; }
        [Required(ErrorMessage = "*")]
        public string employeename { get; set; }
        [Required(ErrorMessage = "*")]
        public int employeesalary { get; set; }
    }
}