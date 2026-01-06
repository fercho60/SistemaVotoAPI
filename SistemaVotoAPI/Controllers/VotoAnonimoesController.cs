using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVotoModelos;

namespace SistemaVotoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotoAnonimoesController : ControllerBase
    {
        private readonly SistemaVotoAPIContext _context;

        public VotoAnonimoesController(SistemaVotoAPIContext context)
        {
            _context = context;
        }

        // GET: api/VotoAnonimoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VotoAnonimo>>> GetVotoAnonimo()
        {
            return await _context.VotoAnonimo.ToListAsync();
        }

        // GET: api/VotoAnonimoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VotoAnonimo>> GetVotoAnonimo(Guid id)
        {
            var votoAnonimo = await _context.VotoAnonimo.FindAsync(id);

            if (votoAnonimo == null)
            {
                return NotFound();
            }

            return votoAnonimo;
        }

        // PUT: api/VotoAnonimoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVotoAnonimo(Guid id, VotoAnonimo votoAnonimo)
        {
            if (id != votoAnonimo.Id)
            {
                return BadRequest();
            }

            _context.Entry(votoAnonimo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VotoAnonimoExists(id))
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

        // POST: api/VotoAnonimoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VotoAnonimo>> PostVotoAnonimo(VotoAnonimo votoAnonimo)
        {
            _context.VotoAnonimo.Add(votoAnonimo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVotoAnonimo", new { id = votoAnonimo.Id }, votoAnonimo);
        }

        // DELETE: api/VotoAnonimoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVotoAnonimo(Guid id)
        {
            var votoAnonimo = await _context.VotoAnonimo.FindAsync(id);
            if (votoAnonimo == null)
            {
                return NotFound();
            }

            _context.VotoAnonimo.Remove(votoAnonimo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VotoAnonimoExists(Guid id)
        {
            return _context.VotoAnonimo.Any(e => e.Id == id);
        }
    }
}
