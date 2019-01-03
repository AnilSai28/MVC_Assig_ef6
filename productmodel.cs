using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_ef6_example.Models
{
    public class productmodel
    {
        public int productid { get; set; }
        public string productname { get; set; }
        public int productprice { get; set; }
        public DateTime productaddeddate { get; set; }
    }
}