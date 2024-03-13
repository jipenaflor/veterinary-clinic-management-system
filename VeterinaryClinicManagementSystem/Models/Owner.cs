namespace VeterinaryClinicManagementSystem.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }

        public ICollection<Animal> Pets { get; }

        public Owner(string name, string address, string contactNumber)
        {
            Name = name;
            Address = address;
            ContactNumber = contactNumber;
            Pets = new List<Animal>();
        }

        public void AddPets(Animal pet)
        {
            Pets.Add(pet); ;
        }
    }
}
