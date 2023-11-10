using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Jmepromeneavecmesvalises_API.Data;
using Jmepromeneavecmesvalises_API.Models;

namespace Jmepromeneavecmesvalises_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoyageController : ControllerBase
    {
        private readonly Jmepromeneavecmesvalises_APIContext _context;

        public VoyageController(Jmepromeneavecmesvalises_APIContext context)
        {
            _context = context;
        }

        // GET: api/Voyage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VoyageDTO>>> GetVoyage()
        {
            if (_context.Voyage == null)
            {
                return NotFound();
            }

            List<VoyageDTO> Data = new List<VoyageDTO>();

            foreach (Voyage item in await _context.Voyage.ToListAsync())
            {
                Data.Add(new VoyageDTO(item));
            }
            
            return Data;
        }

        // GET: api/Voyage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VoyageDTO>> GetVoyage(int id)
        {
            if (_context.Voyage == null)
            {
                return NotFound();
            }

            var voyage = new VoyageDTO(await _context.Voyage.FindAsync(id));

            if (voyage == null)
            {
                return NotFound();
            }

            return voyage;
        }

        // PUT: api/Voyage/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoyage(int id, VoyageDTO Dto)
        {
            if (id != Dto.Id)
            {
                return BadRequest();
            }

            Voyage voyage = new Voyage(Dto);
            voyage.Proprietaires = _context.Users.Where(u => Dto.UserIDs.Contains(u.Id)).ToList();

            _context.Voyage.Update(voyage);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoyageExists(id))
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

        // POST: api/Voyage
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VoyageDTO>> PostVoyage(VoyageDTO Dto)
        {
            if (_context.Voyage == null)
            {
                return Problem("Entity set 'Jmepromeneavecmesvalises_APIContext.Voyage'  is null.");
            }
            
            Voyage voyage = new Voyage(Dto);
            voyage.Proprietaires = _context.Users.Where(u => Dto.UserIDs.Contains(u.Id)).ToList();

            await _context.Voyage.AddAsync(voyage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoyage", new { id = Dto.Id }, Dto);
        }

        // DELETE: api/Voyage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoyage(int id)
        {
            if (_context.Voyage == null)
            {
                return NotFound();
            }

            var voyage = await _context.Voyage.FindAsync(id);
            if (voyage == null)
            {
                return NotFound();
            }

            _context.Voyage.Remove(voyage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VoyageExists(int id)
        {
            return (_context.Voyage?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}