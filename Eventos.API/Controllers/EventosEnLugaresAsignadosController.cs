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
    public class EventosEnLugaresAsignadosController : ControllerBase
    {
        private readonly AppContext _context;

        public EventosEnLugaresAsignadosController(AppContext context)
        {
            _context = context;
        }

        // GET: api/EventosEnLugaresAsignados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoEnLugarAsignado>>> GetEventoEnLugarAsignado()
        {
            var data = await _context.EventosEnLugaresAsignados
              .Include(ela => ela.Evento)
              .Include(ela => ela.EspacioAsignado)
              .ToListAsync();
            return data;
        }

        // GET: api/EventosEnLugaresAsignados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventoEnLugarAsignado>> GetEventoEnLugarAsignado(int id)
        {
            var eventoEnLugarAsignado = await _context.EventosEnLugaresAsignados.FindAsync(id);

            if (eventoEnLugarAsignado == null)
            {
                return NotFound();
            }

            return eventoEnLugarAsignado;
        }

        // PUT: api/EventosEnLugaresAsignados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventoEnLugarAsignado(int id, EventoEnLugarAsignado eventoEnLugarAsignado)
        {
            if (id != eventoEnLugarAsignado.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(eventoEnLugarAsignado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoEnLugarAsignadoExists(id))
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

        // POST: api/EventosEnLugaresAsignados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventoEnLugarAsignado>> PostEventoEnLugarAsignado(EventoEnLugarAsignado eventoEnLugarAsignado)
        {
            _context.EventosEnLugaresAsignados.Add(eventoEnLugarAsignado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventoEnLugarAsignado", new { id = eventoEnLugarAsignado.Codigo }, eventoEnLugarAsignado);
        }

        // DELETE: api/EventosEnLugaresAsignados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventoEnLugarAsignado(int id)
        {
            var eventoEnLugarAsignado = await _context.EventosEnLugaresAsignados.FindAsync(id);
            if (eventoEnLugarAsignado == null)
            {
                return NotFound();
            }

            _context.EventosEnLugaresAsignados.Remove(eventoEnLugarAsignado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventoEnLugarAsignadoExists(int id)
        {
            return _context.EventosEnLugaresAsignados.Any(e => e.Codigo == id);
        }
    }
}
