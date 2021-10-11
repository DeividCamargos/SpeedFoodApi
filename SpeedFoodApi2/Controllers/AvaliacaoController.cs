using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpeedFoodApi2.Data;
using SpeedFoodApi2.Models;

namespace SpeedFoodApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private readonly SpeedFoodContext _context;

        public AvaliacaoController(SpeedFoodContext context)
        {
            _context = context;
        }

        // GET: api/Avaliacao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Avaliacao>>> GetAvaliacoes()
        {
            return await _context.Avaliacoes.ToListAsync();
        }

        // GET: api/Avaliacao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Avaliacao>> GetAvaliacao(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);

            if (avaliacao == null)
            {
                return NotFound();
            }

            return avaliacao;
        }

        // PUT: api/Avaliacao/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvaliacao(int id, Avaliacao avaliacao)
        {
            if (id != avaliacao.Id)
            {
                return BadRequest();
            }

            _context.Entry(avaliacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvaliacaoExists(id))
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

        // POST: api/Avaliacao 
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<Avaliacao>> PostAvaliacao([FromBody]Avaliacao avaliacao)
        {
            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAvaliacao), new { id = avaliacao.Id }, avaliacao);
        }

        // DELETE: api/Avaliacao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvaliacao(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            _context.Avaliacoes.Remove(avaliacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AvaliacaoExists(int id)
        {
            return _context.Avaliacoes.Any(e => e.Id == id);
        }
    }
}
