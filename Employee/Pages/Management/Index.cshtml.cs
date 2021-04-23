using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.DataLibrary.Models;
using Employee.Extension;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Employee.Pages.Management
{
    public class IndexModel : PageModel
    {
        public List<EmployeeData> EmployeeDatas{ get; set; }
        public void OnGet()
        {
            EmployeeDatas = HttpContext.Session.GetEmployees();

            if (EmployeeDatas.Count() == 0)
            {
                EmployeeDatas = new List<EmployeeData> {
                new EmployeeData{ ID = 1, LastName = "Abarquez", MiddleName = "E.", FirstName = "Aldeene", BirthDate = DateTime.Parse("22/12/1990"), EmployeeType = 1, Rate = 20000.00, TIN="123-456-789-000" },
                new EmployeeData{ ID = 2, LastName = "Abarquez", MiddleName = "A.", FirstName = "Aquil", BirthDate = DateTime.Parse("20/02/2018"), EmployeeType = 2, Rate = 500, TIN="999-999-999-000" }
            };
            }

            HttpContext.Session.SaveEmployee(EmployeeDatas);
        }
    }
}
