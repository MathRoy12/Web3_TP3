using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Jmepromeneavecmesvalises_API.Data;
using Jmepromeneavecmesvalises_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Jmepromeneavecmesvalises_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VoyagesController : ControllerBase
    {
        private readonly Jmepromeneavecmesvalises_APIContext _context;
        private readonly UserManager<User> _userManager;
        private User? user;

        public VoyagesController(Jmepromeneavecmesvalises_APIContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Voyages
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Voyage>>> GetVoyage()
        {
            if (_context.Voyage == null)
            {
                return NotFound();
            }

            List<Voyage> data = new List<Voyage>();
            
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            user = await _context.Users.FindAsync(userId);

            if (user != null)
            {
                data.InsertRange(0,
                    await _context.Voyage.Where(v => v.Proprietaires.Contains(user) || v.IsPublic).ToListAsync());
            }
            else
            {
                data.InsertRange(0, await _context.Voyage.Where(v => v.IsPublic).ToListAsync());
            }

            return data;
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
            
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            user = await _context.Users.FindAsync(userId);

            if (!voyage.Proprietaires.Contains(user))
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Message = "la voyage n'apartient pas a cette utilisateur" });
            }

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
            
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Message = "Il n'y a aucun utilisateur de connecter" });
            }
            
            voyage.Proprietaires.Add(user);
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