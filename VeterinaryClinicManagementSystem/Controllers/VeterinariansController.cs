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
    public class VeterinariansController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VeterinariansController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Veterinarians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veterinarian>>> GetVeterinarian()
        {
            return await _context.Veterinarian.ToListAsync();
        }

        // GET: api/Veterinarians/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Veterinarian>> GetVeterinarian(int id)
        {
            var veterinarian = await _context.Veterinarian.FindAsync(id);

            if (veterinarian == null)
            {
                return NotFound();
            }

            return veterinarian;
        }

        // PUT: api/Veterinarians/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeterinarian(int id, Veterinarian veterinarian)
        {
            if (id != veterinarian.Id)
            {
                return BadRequest();
            }

            _context.Entry(veterinarian).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeterinarianExists(id))
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

        // POST: api/Veterinarians
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Veterinarian>> PostVeterinarian(Veterinarian veterinarian)
        {
            _context.Veterinarian.Add(veterinarian);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVeterinarian", new { id = veterinarian.Id }, veterinarian);
        }

        // DELETE: api/Veterinarians/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeterinarian(int id)
        {
            var veterinarian = await _context.Veterinarian.FindAsync(id);
            if (veterinarian == null)
            {
                return NotFound();
            }

            _context.Veterinarian.Remove(veterinarian);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VeterinarianExists(int id)
        {
            return _context.Veterinarian.Any(e => e.Id == id);
        }
    }
}
