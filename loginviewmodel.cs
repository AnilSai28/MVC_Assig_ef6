using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mvc_ef6_example.Models
{
    public class loginviewmodel
    {
        [Required(ErrorMessage ="*")]
        [Display(Name ="login id")]
        public int loginid { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "password")]
        public string password { get; set; }
    }
}