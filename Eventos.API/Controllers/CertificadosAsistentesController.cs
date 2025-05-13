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
    public class CertificadosAsistentesController : ControllerBase
    {
        private readonly AppContext _context;

        public CertificadosAsistentesController(AppContext context)
        {
            _context = context;
        }

        // GET: api/CertificadosAsistentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CertificadoAsistente>>> GetCertificadoAsistente()
        {
            var data = await _context.CertificadosAsistentes
                .Include(ca => ca.Certificado)
                .Include(ca => ca.Asistente)
                .ToListAsync();
            return data;
        }

        // GET: api/CertificadosAsistentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CertificadoAsistente>> GetCertificadoAsistente(int id)
        {
            var certificadoAsistente = await _context.CertificadosAsistentes.FindAsync(id);

            if (certificadoAsistente == null)
            {
                return NotFound();
            }

            return certificadoAsistente;
        }

        // PUT: api/CertificadosAsistentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertificadoAsistente(int id, CertificadoAsistente certificadoAsistente)
        {
            if (id != certificadoAsistente.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(certificadoAsistente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificadoAsistenteExists(id))
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

        // POST: api/CertificadosAsistentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CertificadoAsistente>> PostCertificadoAsistente(CertificadoAsistente certificadoAsistente)
        {
            _context.CertificadosAsistentes.Add(certificadoAsistente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCertificadoAsistente", new { id = certificadoAsistente.Codigo }, certificadoAsistente);
        }

        // DELETE: api/CertificadosAsistentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificadoAsistente(int id)
        {
            var certificadoAsistente = await _context.CertificadosAsistentes.FindAsync(id);
            if (certificadoAsistente == null)
            {
                return NotFound();
            }

            _context.CertificadosAsistentes.Remove(certificadoAsistente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CertificadoAsistenteExists(int id)
        {
            return _context.CertificadosAsistentes.Any(e => e.Codigo == id);
        }
    }
}
