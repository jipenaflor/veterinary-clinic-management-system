namespace VeterinaryClinicManagementSystem.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;

        public ICollection<Pet> Pets { get; set; } = new List<Pet>();

        public void AddPet(Pet pet)
        {
            Pets.Add(pet);
        }

        public void RemovePet(Pet pet)
        {
            Pets.Remove(pet);
        }
    }
}
