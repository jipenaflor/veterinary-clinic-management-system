namespace VeterinaryClinicManagementSystem.Models
{
    public class Veterinarian
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }

        public Veterinarian(string name, string contactNumber)
        {
            Name = name;
            ContactNumber = contactNumber;
        }
    }
}
