using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SSGTaskManager.Models;

namespace SSGTaskManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SSGTaskManager.Models.ETC_Inventory> ETC_Inventory { get; set; } = default!;
    }
}