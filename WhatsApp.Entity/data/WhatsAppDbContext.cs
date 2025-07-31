using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WhatsApp.Entity.Models;

namespace WhatsApp.Entity.data
{
    public class WhatsAppDbContext : IdentityDbContext<RegisterUsers>
    {
        public WhatsAppDbContext(DbContextOptions<WhatsAppDbContext> options) : base(options)
        {

        }
        public DbSet<RegisterUsers> RegisterUsers { get; set; }
    }
}
