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
    public class CertificadosPonentesController : ControllerBase
    {
        private readonly AppContext _context;

        public CertificadosPonentesController(AppContext context)
        {
            _context = context;
        }

        // GET: api/CertificadosPonentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CertificadoPonente>>> GetCertificadoPonente()
        {
            var data = await _context.CertificadosPonentes
                .Include(cp => cp.Certificado)
                .Include(cp=> cp.Ponente)
                .ToListAsync();
            return data;
        }

        // GET: api/CertificadosPonentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CertificadoPonente>> GetCertificadoPonente(int id)
        {
            var certificadoPonente = await _context.CertificadosPonentes.FindAsync(id);

            if (certificadoPonente == null)
            {
                return NotFound();
            }

            return certificadoPonente;
        }

        // PUT: api/CertificadosPonentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertificadoPonente(int id, CertificadoPonente certificadoPonente)
        {
            if (id != certificadoPonente.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(certificadoPonente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificadoPonenteExists(id))
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

        // POST: api/CertificadosPonentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CertificadoPonente>> PostCertificadoPonente(CertificadoPonente certificadoPonente)
        {
            _context.CertificadosPonentes.Add(certificadoPonente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCertificadoPonente", new { id = certificadoPonente.Codigo }, certificadoPonente);
        }

        // DELETE: api/CertificadosPonentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificadoPonente(int id)
        {
            var certificadoPonente = await _context.CertificadosPonentes.FindAsync(id);
            if (certificadoPonente == null)
            {
                return NotFound();
            }

            _context.CertificadosPonentes.Remove(certificadoPonente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CertificadoPonenteExists(int id)
        {
            return _context.CertificadosPonentes.Any(e => e.Codigo == id);
        }
    }
}
