using Employee.DataLibrary.Models;
using Employee.Extension;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Instantiate
{
    public class InstantiateValues
    {

        public List<EmployeeType> GetEmployeeTypes()
        {

            List<EmployeeType> employeeTypes = new List<EmployeeType>() {
                new EmployeeType() {TypeID = 1, Type = "Regular"},
                new EmployeeType() {TypeID = 2, Type = "Contractual" }
            };

            return employeeTypes;
        }

    }
}
