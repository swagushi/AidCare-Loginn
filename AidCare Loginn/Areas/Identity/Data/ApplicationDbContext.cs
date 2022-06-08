using AidCare_Loginn.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AidCare_Loginn.Models;

namespace AidCare_Loginn.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<AidCare_Loginn.Models.member>? member { get; set; }

    public DbSet<AidCare_Loginn.Models.donation>? donation { get; set; }

    public DbSet<AidCare_Loginn.Models.Event>? Event { get; set; }
}
