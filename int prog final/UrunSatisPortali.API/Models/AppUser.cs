using Microsoft.AspNetCore.Identity;

namespace UrunSatisPortali.API.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
