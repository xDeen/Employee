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
    public class EncodeModel : PageModel
    {
        private readonly IEmployeeMethods _employeeMethods;

        public EncodeModel(IEmployeeMethods employeeMethods)
        {
            _employeeMethods = employeeMethods;
        }
        public EmployeeData EmployeeData { get; set; }
        [BindProperty]
        public EmployeeAttendance EmployeeAttendance { get; set; }
        public List<SelectListItem> EmployeeTypes { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            EmployeeTypes = _employeeMethods.GetEmployeeTypes().ConvertAll(x => { return new SelectListItem() { Text = x.Type, Value = x.TypeID.ToString() }; });

            EmployeeData = HttpContext.Session.GetEmployees().Where(r => r.ID == id).FirstOrDefault();
            EmployeeAttendance = HttpContext.Session.GetEmployeeAttendance().Where(r => r.EmployeeID == id).FirstOrDefault();
            if (EmployeeAttendance == null)
            {
                EmployeeAttendance = new EmployeeAttendance() { EmployeeID = id, DaysAbsent = 0, DaysPresent = 0 };

            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync() 
        {
            var _employeeAttendance = HttpContext.Session.GetEmployeeAttendance();
            if (_employeeAttendance.Where(r => r.EmployeeID == EmployeeAttendance.EmployeeID).FirstOrDefault() != null)
            {
                _employeeAttendance.Where(r => r.EmployeeID == EmployeeAttendance.EmployeeID).FirstOrDefault().DaysAbsent = EmployeeAttendance.DaysAbsent;
                _employeeAttendance.Where(r => r.EmployeeID == EmployeeAttendance.EmployeeID).FirstOrDefault().DaysPresent = EmployeeAttendance.DaysPresent;
            }
            else
            {
                _employeeAttendance.Add(EmployeeAttendance);
            }

            HttpContext.Session.SaveEmployeeAttendance(_employeeAttendance);
            
            return RedirectToPage("Index");
        }


    }
}
