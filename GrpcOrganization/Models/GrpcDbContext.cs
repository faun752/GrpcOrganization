using Microsoft.EntityFrameworkCore;

namespace GrpcOrganization.Models
{
    public class GrpcDbContext : DbContext
    {
        public GrpcDbContext(DbContextOptions<GrpcDbContext> options) : base(options)
        {
        }

        public DbSet<Organization> Organizations { get; set; }
    }
}
