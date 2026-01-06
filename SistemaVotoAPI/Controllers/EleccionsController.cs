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
    public class EleccionsController : ControllerBase
    {
        private readonly SistemaVotoAPIContext _context;

        public EleccionsController(SistemaVotoAPIContext context)
        {
            _context = context;
        }

        // GET: api/Eleccions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Eleccion>>> GetEleccion()
        {
            return await _context.Eleccion.ToListAsync();
        }

        // GET: api/Eleccions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Eleccion>> GetEleccion(int id)
        {
            var eleccion = await _context.Eleccion.FindAsync(id);

            if (eleccion == null)
            {
                return NotFound();
            }

            return eleccion;
        }

        // PUT: api/Eleccions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEleccion(int id, Eleccion eleccion)
        {
            if (id != eleccion.Id)
            {
                return BadRequest();
            }

            _context.Entry(eleccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EleccionExists(id))
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

        // POST: api/Eleccions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Eleccion>> PostEleccion(Eleccion eleccion)
        {
            _context.Eleccion.Add(eleccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEleccion", new { id = eleccion.Id }, eleccion);
        }

        // DELETE: api/Eleccions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEleccion(int id)
        {
            var eleccion = await _context.Eleccion.FindAsync(id);
            if (eleccion == null)
            {
                return NotFound();
            }

            _context.Eleccion.Remove(eleccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EleccionExists(int id)
        {
            return _context.Eleccion.Any(e => e.Id == id);
        }
    }
}
