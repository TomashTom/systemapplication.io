using Microsoft.AspNetCore.Identity;

namespace System.Web.Project.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Event> Events { get; set; }

    }
}
