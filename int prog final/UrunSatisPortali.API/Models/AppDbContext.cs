using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UrunSatisPortali.API.Models;
using UrunSatiSPortali.Models;

namespace UrunSatisPortali.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Urun> Urun { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
