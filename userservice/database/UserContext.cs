using Microsoft.EntityFrameworkCore;
using userservice.model;

namespace userservice.database
{
    public class UserContext : DbContext
    {
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=UserDatabase;User=sa;Password=Fortuna2022!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(p => p.Email)
                .IsUnique(true);
        }
    }
}