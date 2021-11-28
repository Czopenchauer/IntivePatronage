using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<User>()
                .Property(x => x.FirstName)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            modelBuilder.Entity<User>()
                .Property(x => x.LastName)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            modelBuilder.Entity<User>()
                .Property(x => x.DateOfBirth)
                .IsRequired()
                .HasColumnType("datetime2(0)");

            modelBuilder.Entity<User>()
                .Property(x => x.Gender)
                .IsRequired()
                .HasColumnType("bit");

            modelBuilder.Entity<User>()
                .Property(x => x.Weight)
                .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<User>()
                .Property(x => x.AddressId)
                .IsRequired();


            modelBuilder.Entity<Address>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Address>()
                .Property(x => x.Country)
                .IsRequired()
                .HasColumnType("nvarchar(100)");

            modelBuilder.Entity<Address>()
                .Property(x => x.City)
                .IsRequired()
                .HasColumnType("nvarchar(100)");

            modelBuilder.Entity<Address>()
                .Property(x => x.PostCode)
                .IsRequired()
                .HasColumnType("nvarchar(10)");

            modelBuilder.Entity<Address>()
                .Property(x => x.Street)
                .IsRequired()
                .HasColumnType("nvarchar(100)");

            modelBuilder.Entity<Address>()
                .Property(x => x.HouseNumber)
                .IsRequired()
                .HasColumnType("nvarchar(10)");

            modelBuilder.Entity<Address>()
                .Property(x => x.LocalNumber)
                .HasColumnType("nvarchar(10)");

            modelBuilder.Entity<User>()
                .HasOne(a => a.Address)
                .WithOne(u => u.User)
                .HasForeignKey<User>(u => u.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
