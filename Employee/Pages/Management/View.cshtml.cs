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

namespace Employee.Pages.Management
{
    public class ViewModel : PageModel
    {
        private readonly IEmployeeMethods _employeeMethods;

        public ViewModel(IEmployeeMethods employeeMethods)
        {
            _employeeMethods = employeeMethods;
        }
        public EmployeeData EmployeeData { get; set; }
        public List<SelectListItem> EmployeeTypes { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            EmployeeTypes = _employeeMethods.GetEmployeeTypes().ConvertAll(x => { return new SelectListItem() { Text = x.Type, Value = x.TypeID.ToString() }; });

            EmployeeData = HttpContext.Session.GetEmployees().Where(r => r.ID == id).FirstOrDefault();
            return Page();
        }
     }
}
