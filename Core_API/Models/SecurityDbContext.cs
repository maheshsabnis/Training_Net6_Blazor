using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Core_API.Models
{
    public class SecurityDbContext :IdentityDbContext
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
