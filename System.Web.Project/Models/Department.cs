using System.ComponentModel.DataAnnotations;

namespace System.Web.Project.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; }
        

        
        public Department()
        {

        }
    }

}
