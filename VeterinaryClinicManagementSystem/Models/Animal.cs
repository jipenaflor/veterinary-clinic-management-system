﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VeterinaryClinicManagementSystem.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public string Sex { get; set; }
        public DateTime Birthdate { get; set; }

        public Dictionary<string, DateTime> Vaccinations { get; }

        public int OwnerId { get; set; }

        public Owner Owner { get; set; } = null!;

        public ICollection<Veterinarian> Veterinarians { get; }
        
        public Animal(string name, string species, string breed, string sex, DateTime birthdate, Owner owner)
        {
            Name = name;
            Species = species;
            Breed = breed;
            Sex = sex;
            Birthdate = birthdate;
            Vaccinations = new Dictionary<string, DateTime>();
            Owner = owner;
            Veterinarians = new List<Veterinarian>();
        }

        public void AddVaccinations(string vaccine, DateTime dateAdministered)
        {
            Vaccinations.Add(vaccine, dateAdministered);
        }

        public void AddVeterinarians(Veterinarian veterinarian)
        {
            Veterinarians.Add(veterinarian);
        }
    }
}
