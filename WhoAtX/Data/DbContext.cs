using Microsoft.EntityFrameworkCore;
using WhoAtX.Models;

namespace WhoAtX.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<UserProfile> UserProfiles { get; set; }
}
