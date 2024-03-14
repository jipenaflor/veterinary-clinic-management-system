using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VeterinaryClinicManagementSystem.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public string Sex { get; set; }
        public DateOnly Birthdate { get; set; }

        public Dictionary<string, DateOnly> Vaccinations { get; set; } = new Dictionary<string, DateOnly>();

        public int OwnerId { get; set; }

        public Owner Owner { get; set; } = null!;

        public ICollection<Veterinarian> Veterinarians { get; set; } = new List<Veterinarian>();

        public void AddVaccinations(string vaccine, DateOnly dateAdministered)
        {
            Vaccinations.Add(vaccine, dateAdministered);
        }

        public void AddVeterinarians(Veterinarian veterinarian)
        {
            Veterinarians.Add(veterinarian);
        }
    }
}
