using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinicManagementSystem.Data;
using VeterinaryClinicManagementSystem.Models;

namespace VeterinaryClinicManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PetsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Pets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
        {
            return await _context.Pets
                .ToListAsync();
        }

        // GET: api/Pets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPet(int id)
        {
            var pet = await _context.Pets
                .Include("Owner")
                .Include("Veterinarian")
                .Include("Vaccines")
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pet == null)
            {
                return NotFound();
            }

            return pet;
        }


        // PUT: api/Pets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPet(int id, Pet pet)
        {
            if (id != pet.Id)
            {
                return BadRequest();
            }

            _context.Entry(pet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pet>> PostPet(Pet pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPet", new { id = pet.Id }, pet);
        }

        [HttpPost("{id}/Vaccines")]
        public async Task<ActionResult<Pet>> AddVaccineToPet(int id, Vaccine vaccine)
        {
            var pet = await _context.Pets.FindAsync(id);

            if (pet == null)
            {
                return NotFound();
            }

            pet.Vaccines.Add(vaccine);
            vaccine.Pet = pet;

            await _context.SaveChangesAsync();

            return pet;
        }


        [HttpPost("{PetId}/Veterinarians/{VetId}")]
        public async Task<ActionResult<Pet>> AddVeterinarianToPet(int PetId, int VetId)
        {
            var pet = await _context.Pets.FindAsync(PetId);
            var vet = await _context.Veterinarians.FindAsync(VetId);

            if (pet == null || vet == null)
            {
                return NotFound();
            }

            if (pet.VeterinarianId != null)
            {
                var initialVet = await _context.Veterinarians.FindAsync(pet.VeterinarianId);
                initialVet.RemovePatient(pet);
            }

            vet.AddPatient(pet);
            pet.Veterinarian = vet;

            await _context.SaveChangesAsync();

            return pet;
        }

        // DELETE: api/Pets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }

            if (pet.OwnerId != null)
            {
                var initialOwner = await _context.Owners.FindAsync(pet.OwnerId);
                initialOwner.RemovePet(pet);
            }

            if (pet.VeterinarianId != null)
            {
                var initialVet = await _context.Veterinarians.FindAsync(pet.VeterinarianId);
                initialVet.RemovePatient(pet);
            }

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{PetId}/Vaccines/{VaxId}")]
        public async Task<IActionResult> RemoveVaccineFromPet(int PetId, int VaxId)
        {
            var pet = await _context.Pets.FindAsync(PetId);
            var vaccine = await _context.Vaccines.FindAsync(VaxId);

            if (pet == null || vaccine == null)
            {
                return NotFound();
            }

            pet.Vaccines.Remove(pet.Vaccines.First(v => v.Id == VaxId));
            _context.Vaccines.Remove(vaccine);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{PetId}/Veterinarians/{VetId}")]
        public async Task<IActionResult> RemoveVetFromPet(int PetId, int VetId)
        {
            var pet = await _context.Pets.FindAsync(PetId);
            var vet = await _context.Veterinarians.FindAsync(VetId);

            if (pet == null || vet == null || pet.Veterinarian == null)
            {
                return NotFound();
            }

            vet.Patients.Remove(vet.Patients.First(p => p.Id == VetId));

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PetExists(int id)
        {
            return _context.Pets.Any(e => e.Id == id);
        }
    }
}
