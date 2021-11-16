using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DapperMvcProject.Models
{
    public class EmpModel
    {
        [Required]
        public int Empid { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}