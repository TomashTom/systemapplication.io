using System.ComponentModel.DataAnnotations;

namespace System.Web.Project.Models
{
    public class Location
    {
        
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        //Relational data
        public virtual ICollection<Event>? Events { get; set; }

        public Location()
        {

        }
       

    }
}
