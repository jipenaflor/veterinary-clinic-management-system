using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VeterinaryClinicManagementSystem.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Species { get; set; } = null!;
        public string? Breed { get; set; }
        public string Sex { get; set; } = null!;
        public DateOnly Birthdate { get; set; }

        public int? OwnerId { get; set; }

        public Owner? Owner { get; set; }

        public int? VeterinarianId { get; set; }

        public Veterinarian? Veterinarian { get; set; }

        [NotMapped]
        public ICollection<Vaccine> Vaccines { get; set; } = new List<Vaccine>();

    }
}
