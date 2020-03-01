using Microsoft.EntityFrameworkCore;
using Demetrios.Models;

namespace Demetrios.Context
{
    public class ContatoPostDatabaseContext : DbContext
    {
        public ContatoPostDatabaseContext(
            DbContextOptions<ContatoPostDatabaseContext> dbContextOptions)
            : base(dbContextOptions) { }

        public DbSet<ContatoPost> ContatoPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContatoPost>()
                .HasKey(x => x.Id);
        }
    }
}
