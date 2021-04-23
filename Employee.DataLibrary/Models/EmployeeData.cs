using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Employee.DataLibrary.Models
{
    public class EmployeeData
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required]
        public string TIN { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:n}")]
        public double Rate { get; set; }
        [Required]
        public int EmployeeType { get; set; }


    }
}
