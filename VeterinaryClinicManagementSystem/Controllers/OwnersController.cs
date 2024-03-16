using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using VeterinaryClinicManagementSystem.Data;
using VeterinaryClinicManagementSystem.Models;

namespace VeterinaryClinicManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OwnersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Owners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Owner>>> GetOwner()
        {
            return await _context.Owners
                .Include("Pets")
                .ToListAsync();
        }

        // GET: api/Owners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> GetOwner(int id)
        {
            var owner = await _context.Owners
                .Include("Pets")
                .FirstOrDefaultAsync(o => o.Id == id);

            if (owner == null)
            {
                return NotFound();
            }

            return owner;
        }


        // PUT: api/Owners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwner(int id, Owner owner)
        {
            if (id != owner.Id)
            {
                return BadRequest();
            }

            _context.Entry(owner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnerExists(id))
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

        // POST: api/Owners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Owner>> PostOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOwner", new { id = owner.Id }, owner);
        }

        [HttpPost("{OwnerId}/Pets/{PetId}")]
        public async Task<ActionResult<Owner>> AddPetToOwner(int OwnerId, int PetId)
        {
            var owner = await _context.Owners.FindAsync(OwnerId);
            var pet = await _context.Pets.FindAsync(PetId);

            if (owner == null || pet == null)
            {
                return NotFound();
            }

            if (pet.OwnerId != null)
            {
                var initialOwner = await _context.Veterinarians.FindAsync(pet.OwnerId);
                initialOwner.RemovePatient(pet);
            }

            owner.AddPet(pet);
            pet.Owner = owner;

            await _context.SaveChangesAsync();
         

            return owner;
        }

        // DELETE: api/Owners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }

            _context.Owners.Remove(owner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{OwnerId}/Pets/{PetId}")]
        public async Task<IActionResult> RemovePetFromOwner(int OwnerId, int PetId)
        {
            var owner = await _context.Owners.FindAsync(OwnerId);
            var pet = await _context.Pets.FindAsync(PetId);

            if (owner == null || pet == null || pet.Owner == null)
            {
                return NotFound();
            }

            owner.Pets.Remove(owner.Pets.First(p => p.Id == PetId));

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OwnerExists(int id)
        {
            return _context.Owners.Any(e => e.Id == id);
        }
    }
}
