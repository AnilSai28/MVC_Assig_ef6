using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc_ef6_example.Models
{
    [Table("tbl_customers")]
    public class customermodel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int customerid { get; set; }

        [Required(ErrorMessage ="*")]
        [StringLength(100)]
        public string customername { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(100)]
        public string customerpassword { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(100)]
        public string customercity { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(100)]
        [Column("customeremailaddress")]
        public string customeremailid { get; set; }

        [NotMapped]
        public string customerdetails { get; set; }

        public List<ordermodel> orders { get; set; }


    }
}