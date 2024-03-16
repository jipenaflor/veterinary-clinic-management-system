using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VeterinaryClinicManagementSystem.Models;

namespace VeterinaryClinicManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pet> Pets { get; set; } = default!;
        public DbSet<Owner> Owners { get; set; } = default!;
        public DbSet<Veterinarian> Veterinarians { get; set; } = default!;
        public DbSet<Vaccine> Vaccines { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Owner)
                .WithMany(p => p.Pets)
                .HasForeignKey(p => p.OwnerId);

            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Veterinarian)
                .WithMany(p => p.Patients)
                .HasForeignKey(p => p.VeterinarianId);

            modelBuilder.Entity<Pet>()
                .HasMany(p => p.Vaccines)
                .WithOne(p => p.Pet)
                .HasForeignKey(p => p.PetId);
        }
    }
}
