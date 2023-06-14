using Microsoft.AspNetCore.Mvc.Rendering;

namespace System.Web.Project.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }

        public List<SelectListItem> Department = new List<SelectListItem>();
        public string DepartmentName { get; set; }

        public EmployeeViewModel(Employee myemployee, List<Department> Departments)
        {
            //DepartmentName = myemployee.Department.Name;
            Employee = myemployee;
            foreach (var dep in Departments)
            {
                Department.Add(new SelectListItem() { Text = dep.Name });
            }
        }
        public EmployeeViewModel(List<Department> Departments)
        {

            foreach (var dep in Departments)
            {
                Department.Add(new SelectListItem() { Text = dep.Name });
            }
        }
        public EmployeeViewModel()
        {

        }

    }
}
