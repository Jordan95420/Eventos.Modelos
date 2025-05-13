using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eventos.Modelos;

namespace Eventos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscripcionesAsistentesController : ControllerBase
    {
        private readonly AppContext _context;

        public InscripcionesAsistentesController(AppContext context)
        {
            _context = context;
        }

        // GET: api/InscripcionesAsistentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InscripcionAsistente>>> GetInscripcionAsistente()
        {

            var data = await _context.InscripcionesAsistentes
              .Include(ia => ia.Asistente)
              .Include(ia => ia.Inscripcion)
              .ToListAsync();
            return data;
        }

        // GET: api/InscripcionesAsistentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InscripcionAsistente>> GetInscripcionAsistente(int id)
        {
            var inscripcionAsistente = await _context.InscripcionesAsistentes.FindAsync(id);

            if (inscripcionAsistente == null)
            {
                return NotFound();
            }

            return inscripcionAsistente;
        }

        // PUT: api/InscripcionesAsistentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInscripcionAsistente(int id, InscripcionAsistente inscripcionAsistente)
        {
            if (id != inscripcionAsistente.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(inscripcionAsistente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscripcionAsistenteExists(id))
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

        // POST: api/InscripcionesAsistentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InscripcionAsistente>> PostInscripcionAsistente(InscripcionAsistente inscripcionAsistente)
        {
            _context.InscripcionesAsistentes.Add(inscripcionAsistente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInscripcionAsistente", new { id = inscripcionAsistente.Codigo }, inscripcionAsistente);
        }

        // DELETE: api/InscripcionesAsistentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInscripcionAsistente(int id)
        {
            var inscripcionAsistente = await _context.InscripcionesAsistentes.FindAsync(id);
            if (inscripcionAsistente == null)
            {
                return NotFound();
            }

            _context.InscripcionesAsistentes.Remove(inscripcionAsistente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InscripcionAsistenteExists(int id)
        {
            return _context.InscripcionesAsistentes.Any(e => e.Codigo == id);
        }
    }
}
