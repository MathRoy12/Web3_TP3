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
    public class VoyagesController : ControllerBase
    {
        private readonly Jmepromeneavecmesvalises_APIContext _context;

        public VoyagesController(Jmepromeneavecmesvalises_APIContext context)
        {
            _context = context;
        }

        // GET: api/Voyages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voyage>>> GetVoyage()
        {
            if (_context.Voyage == null)
            {
                return NotFound();
            }

            return await _context.Voyage.ToListAsync();
        }

        // GET: api/Voyages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Voyage>> GetVoyage(int id)
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

            return voyage;
        }

        // PUT: api/Voyages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoyage(int id, Voyage voyage)
        {
            if (id != voyage.Id)
            {
                return BadRequest();
            }

            _context.Entry(voyage).State = EntityState.Modified;

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

        // POST: api/Voyages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Voyage>> PostVoyage(Voyage voyage)
        {
            if (_context.Voyage == null)
            {
                return Problem("Entity set 'Jmepromeneavecmesvalises_APIContext.Voyage'  is null.");
            }

            _context.Voyage.Add(voyage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoyage", new { id = voyage.Id }, voyage);
        }

        // DELETE: api/Voyages/5
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