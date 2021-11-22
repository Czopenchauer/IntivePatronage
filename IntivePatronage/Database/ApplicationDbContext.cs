using IntivePatronage.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntivePatronage.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(a => a.Address)
                .WithOne(u => u.User)
                .HasForeignKey<User>(u => u.AddressId);
        }
    }
}
