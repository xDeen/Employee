using Employee.DataLibrary.Models;

namespace Employee.DataLibrary.Data
{
    public interface IEmployeeMethods
    {
        string ComputeSalary(EmployeeData employeeData, EmployeeAttendance employeeAttendance);
    }
}