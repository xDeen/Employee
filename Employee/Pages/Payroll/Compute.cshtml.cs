using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.DataLibrary.Data;
using Employee.DataLibrary.Models;
using Employee.Extension;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Employee.Pages.Payroll
{
    public class ComputeModel : PageModel
    {
        private readonly IEmployeeMethods _employeeMethods;

        public ComputeModel(IEmployeeMethods employeeMethods)
        {
            _employeeMethods = employeeMethods;
        }
        public EmployeeData EmployeeData { get; set; }
        public EmployeeAttendance EmployeeAttendance { get; set; }
        public string NetIncome { get; set; }
        public List<SelectListItem> EmployeeTypes { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            EmployeeTypes = new List<SelectListItem>
            {
                new SelectListItem{Text = "Regular", Value = "1"},
                new SelectListItem{Text = "Contract", Value = "2"}
            };
            EmployeeData =  HttpContext.Session.GetEmployees().Where(r => r.ID == id).FirstOrDefault();
            EmployeeAttendance = HttpContext.Session.GetEmployeeAttendance().Where(r => r.EmployeeID == id).FirstOrDefault();
            if (EmployeeAttendance == null)
            {
                EmployeeAttendance = new EmployeeAttendance() { EmployeeID = id, DaysAbsent = 0, DaysPresent = 0 };

            }

            NetIncome = _employeeMethods.ComputeSalary(EmployeeData, EmployeeAttendance);

            return Page();
        }
    }
}
