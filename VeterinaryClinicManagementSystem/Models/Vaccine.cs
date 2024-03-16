namespace VeterinaryClinicManagementSystem.Models
{
    public class Vaccine
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateOnly DateAdministered { get; set; }
        public int PetId { get; set; }
        public Pet? Pet { get; set; }
    }
}
