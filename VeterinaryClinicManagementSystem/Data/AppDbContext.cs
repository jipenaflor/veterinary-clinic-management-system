using Microsoft.EntityFrameworkCore;
using VeterinaryClinicManagementSystem.Models;

namespace VeterinaryClinicManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pet> Pets { get; set; }
    }
}
