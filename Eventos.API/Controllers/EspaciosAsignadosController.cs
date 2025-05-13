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
    public class EspaciosAsignadosController : ControllerBase
    {
        private readonly AppContext _context;

        public EspaciosAsignadosController(AppContext context)
        {
            _context = context;
        }

        // GET: api/EspaciosAsignados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EspacioAsignado>>> GetEspacioAsignado()
        {
            var data = await _context.EspaciosAsignados
                .Include(ea => ea.EventosEnLugaresAsignados)
                .ToListAsync();
            return data;
        }

        // GET: api/EspaciosAsignados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EspacioAsignado>> GetEspacioAsignado(int id)
        {
            var espacioAsignado = await _context.EspaciosAsignados.FindAsync(id);

            if (espacioAsignado == null)
            {
                return NotFound();
            }

            return espacioAsignado;
        }

        // PUT: api/EspaciosAsignados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspacioAsignado(int id, EspacioAsignado espacioAsignado)
        {
            if (id != espacioAsignado.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(espacioAsignado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspacioAsignadoExists(id))
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

        // POST: api/EspaciosAsignados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EspacioAsignado>> PostEspacioAsignado(EspacioAsignado espacioAsignado)
        {
            _context.EspaciosAsignados.Add(espacioAsignado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEspacioAsignado", new { id = espacioAsignado.Codigo }, espacioAsignado);
        }

        // DELETE: api/EspaciosAsignados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspacioAsignado(int id)
        {
            var espacioAsignado = await _context.EspaciosAsignados.FindAsync(id);
            if (espacioAsignado == null)
            {
                return NotFound();
            }

            _context.EspaciosAsignados.Remove(espacioAsignado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EspacioAsignadoExists(int id)
        {
            return _context.EspaciosAsignados.Any(e => e.Codigo == id);
        }
    }
}
