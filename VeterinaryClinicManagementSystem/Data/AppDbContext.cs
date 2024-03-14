using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VeterinaryClinicManagementSystem.Models;

namespace VeterinaryClinicManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pet> Pets { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Owner)
                .WithMany(p => p.Pets)
                .HasForeignKey(p => p.OwnerId);

            modelBuilder.Entity<Pet>(b =>
            { 
                b.Property(p => p.Vaccinations)
                    .HasConversion(
                        d => JsonConvert.SerializeObject(d, Formatting.None),
                        s => JsonConvert.DeserializeObject<Dictionary<string, DateOnly>>(s)
                    )
                    .HasMaxLength(4000);
            });
        }

        public DbSet<VeterinaryClinicManagementSystem.Models.Owner> Owner { get; set; } = default!;
        public DbSet<VeterinaryClinicManagementSystem.Models.Veterinarian> Veterinarian { get; set; } = default!;
    }
}
