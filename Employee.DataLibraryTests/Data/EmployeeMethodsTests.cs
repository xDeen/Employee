
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Employee.DataLibrary.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Employee.DataLibrary.Models;

namespace Employee.DataLibrary.Data.Tests
{
    [TestClass()]
    public class EmployeeMethodsTests
    {
        [TestMethod()]
        public void TestException()
        {
            EmployeeData employeeData = new EmployeeData() { ID = 1, LastName = "Abarquez", MiddleName = "E.", FirstName = "Aldeene", BirthDate = DateTime.Parse("22/12/1990"), EmployeeType = 3, Rate = 20000.00, TIN = "123-456-789-000" }; ;
            EmployeeAttendance employeeAttendance = new EmployeeAttendance() { EmployeeID = 1, DaysAbsent =1, DaysPresent = 0};
            

            IEmployeeMethods employeeMethods = new EmployeeMethods();

            try
            {
                employeeMethods.ComputeSalary(employeeData, employeeAttendance);
                return;
            }
            catch(Exception e)
            {
                StringAssert.Contains(e.Message,"Error");
                return;
            }
            Assert.Fail("No Exception was thrown");


        }
    }
}