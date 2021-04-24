using Employee.DataLibrary.Models;
using System.Collections.Generic;

namespace Employee.DataLibrary.Data
{
    public interface IEmployeeMethods
    {
        List<EmployeeType> GetEmployeeTypes();
        string ComputeSalary(EmployeeData employeeData, EmployeeAttendance employeeAttendance);
    }
}