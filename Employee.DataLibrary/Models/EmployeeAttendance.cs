using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.DataLibrary.Models
{
    public class EmployeeAttendance
    {
        public int EmployeeID { get; set; } 
        public double DaysPresent { get; set; } 
        public double DaysAbsent { get; set; } 
    }
}
