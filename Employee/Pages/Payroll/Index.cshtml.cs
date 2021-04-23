using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.DataLibrary.Models;
using Employee.Extension;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Employee.Pages.Payroll
{
    public class IndexModel : PageModel
    {
        public List<EmployeeData> EmployeeDatas { get; set; }
        public void OnGet()
        {
            EmployeeDatas = HttpContext.Session.GetEmployees();
        }
    }
}
