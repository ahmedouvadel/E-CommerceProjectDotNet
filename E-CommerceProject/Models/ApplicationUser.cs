using Microsoft.AspNetCore.Identity;

namespace E_CommerceProject.Models
{
    public class ApplicationUser: IdentityUser
    {
        public byte[]? ProfileImage { get; set; }
        public IEnumerable<Order>? Orders { get; set; }
        
    }
}
