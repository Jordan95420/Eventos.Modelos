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
    public class PonentesEventosController : ControllerBase
    {
        private readonly AppContext _context;

        public PonentesEventosController(AppContext context)
        {
            _context = context;
        }

        // GET: api/PonentesEventos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PonenteEvento>>> GetPonenteEvento()
        {
            var data = await _context.PonentesEventos
                .Include(pe => pe.Ponente)
                .Include(pe => pe.Evento)
                .ToListAsync();
            return data;
        }

        // GET: api/PonentesEventos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PonenteEvento>> GetPonenteEvento(int id)
        {
            var ponenteEvento = await _context.PonentesEventos.FindAsync(id);

            if (ponenteEvento == null)
            {
                return NotFound();
            }

            return ponenteEvento;
        }

        // PUT: api/PonentesEventos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPonenteEvento(int id, PonenteEvento ponenteEvento)
        {
            if (id != ponenteEvento.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(ponenteEvento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PonenteEventoExists(id))
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

        // POST: api/PonentesEventos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PonenteEvento>> PostPonenteEvento(PonenteEvento ponenteEvento)
        {
            _context.PonentesEventos.Add(ponenteEvento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPonenteEvento", new { id = ponenteEvento.Codigo }, ponenteEvento);
        }

        // DELETE: api/PonentesEventos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePonenteEvento(int id)
        {
            var ponenteEvento = await _context.PonentesEventos.FindAsync(id);
            if (ponenteEvento == null)
            {
                return NotFound();
            }

            _context.PonentesEventos.Remove(ponenteEvento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PonenteEventoExists(int id)
        {
            return _context.PonentesEventos.Any(e => e.Codigo == id);
        }
    }
}
