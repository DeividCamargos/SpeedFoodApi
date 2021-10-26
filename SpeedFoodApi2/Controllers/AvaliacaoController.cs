using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpeedFoodApi2.Data;
using SpeedFoodApi2.Models;

namespace SpeedFoodApi2.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
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
        public async Task<ActionResult<List<Avaliacao>>> GetAvaliacoes()
        {
            try
            {
                var List = await _context.Avaliacoes.AsNoTracking().ToListAsync();

                return Ok(List);            
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível retornar nenhuma avaliação" });
            }
        }
         
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Avaliacao>> GetAvaliacao(int id)
        {
            try
            {
                var avaliacao = await _context.Avaliacoes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (avaliacao == null)
                    return NotFound(new { message = "Id não encontrado" });
                
                return Ok(avaliacao);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível retornar a avaliação" });
            }
        }

        // POST: api/Avaliacao 
        [HttpPost]
        public async Task<ActionResult<Avaliacao>> PostAvaliacao([FromBody] Avaliacao avaliacao)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _context.Avaliacoes.Add(avaliacao);
                await _context.SaveChangesAsync();

                return Ok(avaliacao);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível criar a categoria" });
            }
        }
    }
}
