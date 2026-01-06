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
    public class HistorialParticipacionsController : ControllerBase
    {
        private readonly SistemaVotoAPIContext _context;

        public HistorialParticipacionsController(SistemaVotoAPIContext context)
        {
            _context = context;
        }

        // GET: api/HistorialParticipacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialParticipacion>>> GetHistorialParticipacion()
        {
            return await _context.HistorialParticipacion.ToListAsync();
        }

        // GET: api/HistorialParticipacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialParticipacion>> GetHistorialParticipacion(int id)
        {
            var historialParticipacion = await _context.HistorialParticipacion.FindAsync(id);

            if (historialParticipacion == null)
            {
                return NotFound();
            }

            return historialParticipacion;
        }

        // PUT: api/HistorialParticipacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorialParticipacion(int id, HistorialParticipacion historialParticipacion)
        {
            if (id != historialParticipacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(historialParticipacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialParticipacionExists(id))
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

        // POST: api/HistorialParticipacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HistorialParticipacion>> PostHistorialParticipacion(HistorialParticipacion historialParticipacion)
        {
            _context.HistorialParticipacion.Add(historialParticipacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorialParticipacion", new { id = historialParticipacion.Id }, historialParticipacion);
        }

        // DELETE: api/HistorialParticipacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorialParticipacion(int id)
        {
            var historialParticipacion = await _context.HistorialParticipacion.FindAsync(id);
            if (historialParticipacion == null)
            {
                return NotFound();
            }

            _context.HistorialParticipacion.Remove(historialParticipacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistorialParticipacionExists(int id)
        {
            return _context.HistorialParticipacion.Any(e => e.Id == id);
        }
    }
}
