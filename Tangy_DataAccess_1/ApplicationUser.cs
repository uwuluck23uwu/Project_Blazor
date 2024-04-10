using Microsoft.AspNetCore.Identity;

namespace Tangy_DataAccess_1
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
