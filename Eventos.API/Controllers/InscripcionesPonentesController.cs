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
    public class InscripcionesPonentesController : ControllerBase
    {
        private readonly AppContext _context;

        public InscripcionesPonentesController(AppContext context)
        {
            _context = context;
        }

        // GET: api/InscripcionesPonentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InscripcionPonente>>> GetInscripcionPonente()
        {

            var data = await _context.InscripcionesPonentes
               .Include(ie => ie.Ponente)
              .Include(ie => ie.Inscripcion)
              .ToListAsync();
            return data;
        }

        // GET: api/InscripcionesPonentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InscripcionPonente>> GetInscripcionPonente(int id)
        {
            var inscripcionPonente = await _context.InscripcionesPonentes.FindAsync(id);

            if (inscripcionPonente == null)
            {
                return NotFound();
            }

            return inscripcionPonente;
        }

        // PUT: api/InscripcionesPonentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInscripcionPonente(int id, InscripcionPonente inscripcionPonente)
        {
            if (id != inscripcionPonente.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(inscripcionPonente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscripcionPonenteExists(id))
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

        // POST: api/InscripcionesPonentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InscripcionPonente>> PostInscripcionPonente(InscripcionPonente inscripcionPonente)
        {
            _context.InscripcionesPonentes.Add(inscripcionPonente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInscripcionPonente", new { id = inscripcionPonente.Codigo }, inscripcionPonente);
        }

        // DELETE: api/InscripcionesPonentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInscripcionPonente(int id)
        {
            var inscripcionPonente = await _context.InscripcionesPonentes.FindAsync(id);
            if (inscripcionPonente == null)
            {
                return NotFound();
            }

            _context.InscripcionesPonentes.Remove(inscripcionPonente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InscripcionPonenteExists(int id)
        {
            return _context.InscripcionesPonentes.Any(e => e.Codigo == id);
        }
    }
}
