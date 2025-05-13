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
    public class AsistentesController : ControllerBase
    {
        private readonly AppContext _context;

        public AsistentesController(AppContext context)
        {
            _context = context;
        }

        // GET: api/Asistentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asistente>>> GetAsistente()
        {
            return await _context.Asistentes.ToListAsync();
        }

        // GET: api/Asistentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asistente>> GetAsistente(int id)
        {
            var asistente = await _context.Asistentes.FindAsync(id);

            if (asistente == null)
            {
                return NotFound();
            }

            return asistente;
        }

        // PUT: api/Asistentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsistente(int id, Asistente asistente)
        {
            if (id != asistente.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(asistente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsistenteExists(id))
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

        // POST: api/Asistentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Asistente>> PostAsistente(Asistente asistente)
        {
            _context.Asistentes.Add(asistente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsistente", new { id = asistente.Codigo }, asistente);
        }

        // DELETE: api/Asistentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsistente(int id)
        {
            var asistente = await _context.Asistentes.FindAsync(id);
            if (asistente == null)
            {
                return NotFound();
            }

            _context.Asistentes.Remove(asistente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsistenteExists(int id)
        {
            return _context.Asistentes.Any(e => e.Codigo == id);
        }
    }
}
