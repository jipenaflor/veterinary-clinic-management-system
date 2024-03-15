namespace VeterinaryClinicManagementSystem.Models
{
    public class Veterinarian
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;

        public ICollection<Pet> Patients { get; set; } = new List<Pet>();

        public void AddPatient(Pet pet)
        {
            Patients.Add(pet);
        }

        public void RemovePatient(Pet pet)
        {
            Patients.Remove(pet);
        }

    }
}
