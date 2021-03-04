using Data.Sql.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Sql.EF
{
    public class ForecasterContext : DbContext
    {
        public ForecasterContext(DbContextOptions<ForecasterContext> options)
          : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        DbSet<Project> PROJECTS { get; set; }
        DbSet<Report> REPORTS { get; set; }
    }
}
