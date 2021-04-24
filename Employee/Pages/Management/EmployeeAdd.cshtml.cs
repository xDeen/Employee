using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.DataLibrary.Data;
using Employee.DataLibrary.Models;
using Employee.Extension;
using Employee.Instantiate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Employee.Pages.Management
{
    public class EmployeeAddModel : PageModel
    {
        private readonly IEmployeeMethods _employeeMethods;

        public EmployeeAddModel(IEmployeeMethods employeeMethods)
        {
            _employeeMethods = employeeMethods;
        }
        [BindProperty]
        public EmployeeData EmployeeData { get; set; }
        public List<SelectListItem> EmployeeTypes { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            
            EmployeeTypes = _employeeMethods.GetEmployeeTypes().ConvertAll(x => { return new SelectListItem() { Text = x.Type, Value = x.TypeID.ToString() }; });
            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            
            List<EmployeeData> _employeeDatas = new List<EmployeeData>();
            _employeeDatas = HttpContext.Session.GetEmployees();
            EmployeeData.ID = _employeeDatas.Count + 1;

            _employeeDatas.Add(EmployeeData);
            HttpContext.Session.SaveEmployee(_employeeDatas);

            _employeeDatas = HttpContext.Session.GetEmployees();
            return RedirectToPage("Index");
        }


    }
}
