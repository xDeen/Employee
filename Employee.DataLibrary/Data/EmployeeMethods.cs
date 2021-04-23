using Employee.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.DataLibrary.Data
{
    public class EmployeeMethods : IEmployeeMethods
    {
        public string ComputeSalary(EmployeeData employeeData, EmployeeAttendance employeeAttendance)
        {

            switch (employeeData.EmployeeType)
            {
                case 1:
                    return ComputeRegular(employeeData, employeeAttendance);
                    
                case 2:

                    return ComputeContractual(employeeData, employeeAttendance);

                default:
                    return "0";
            }
        }

        private string ComputeRegular(EmployeeData employeeData, EmployeeAttendance employeeAttendance)
        {

            double tax = employeeData.Rate * 0.12; //(EmployeeData. / 100);
            double dailyrate = employeeData.Rate / 22;
            double absences = dailyrate * employeeAttendance.DaysAbsent;
           // double dailyrate = employeeData.Rate / (22 - employeeAttendance.DaysAbsent);
            double deduction = employeeData.Rate - absences;
            return String.Format("{0:n}", Math.Round(deduction - tax, 2));

        }
        private string ComputeContractual(EmployeeData employeeData, EmployeeAttendance employeeAttendance)
        {

            return String.Format("{0:n}", Math.Round(employeeData.Rate * employeeAttendance.DaysPresent, 2));

        }

    }
}
