using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Aurora.Models;

namespace Aurora.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Aurora.Models.AuroraModel> AuroraModel { get; set; } = default!;
        public DbSet<Aurora.Models.jobLength> jobLength { get; set; } = default!;
        public DbSet<Aurora.Models.timeLength> timeLength { get; set; } = default!;
        public DbSet<Aurora.Models.AuroraModel2> AuroraModel2 { get; set; } = default!;
        public DbSet<Aurora.Models.Difficulty> Difficulty { get; set; } = default!;
        
    }
}