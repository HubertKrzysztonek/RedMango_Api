using Microsoft.AspNetCore.Identity;

namespace RedMango_Api.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
