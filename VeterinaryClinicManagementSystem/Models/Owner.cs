namespace VeterinaryClinicManagementSystem.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }

        public ICollection<Pet> Pets { get; } = new List<Pet>();

        public void AddPets(Pet pet)
        {
            Pets.Add(pet);
        }
    }
}
