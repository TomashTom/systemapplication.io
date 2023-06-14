namespace System.Web.Project.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeCity { get; set; }
        public virtual Department Department { get; set; }

        //public virtual ICollection<Event > Events { get; set; }
        
        //public virtual Location? Location { get; set; }
        public virtual ApplicationUser? User { get; set; }

        public Employee(IFormCollection form, Department department)
        {

            EmployeeName = form["Employee.EmployeeName"].ToString();
            EmployeeSurname = form["Employee.EmployeeSurname"].ToString();
            EmployeePhone = form["Employee.EmployeePhone"].ToString();
            EmployeeAddress = form["Employee.EmployeeAddress"].ToString();
            EmployeeCity = form["Employee.EmployeeCity"].ToString();
            //EmployeeDepartment = form["Employee.EmployeeDepartment"].ToString();
            Department = department;
        }

        public void UpdateEmployee(IFormCollection form, Department department)
        {

            EmployeeName = form["Employee.EmployeeName"].ToString();
            EmployeeSurname = form["Employee.EmployeeSurname"].ToString();
            EmployeePhone = form["Employee.EmployeePhone"].ToString();
            EmployeeAddress = form["Employee.EmployeeAddress"].ToString();
            EmployeeCity = form["Employee.EmployeeCity"].ToString();
            //EmployeeDepartment = form["Employee.EmployeeDepartment"].ToString();
            Department = department;
        }

        public Employee()
        {

        }
    }
}
