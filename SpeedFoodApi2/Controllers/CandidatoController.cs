using System.Collections.Generic;
using System.Globalization;
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
    public class CandidatoController : ControllerBase
    {
        private readonly SpeedFoodContext _context;

        public CandidatoController(SpeedFoodContext context)
        {
            _context = context;
        }

        // GET: api/Candidato
        [HttpGet]
        public async Task<ActionResult<List<Candidato>>> GetAvaliacoes()
        {
            try
            {
                var List = await _context.Candidatos.AsNoTracking().ToListAsync();

                return Ok(List);
            }
            catch 
            {
                return BadRequest(new { message = "Não foi possível retornar nenhuma categoria" });
            }
        }

        // GET: api/Candidato/5
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Candidato>> GetAvaliacao(int? id)
        {
            try
            {
                var candidato = await _context.Candidatos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (candidato == null)
                    return NotFound(new { message = "Id não encontrado " });

                return Ok(candidato);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível retornar  a categoria" });
            }
        }
                
        // POST: api/Candidato
        [HttpPost]
        public async Task<ActionResult<Candidato>> PostAvaliacao([FromBody] Candidato candidato)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            try
            {
                _context.Candidatos.Add(candidato);
                await _context.SaveChangesAsync();
                
                return Ok(candidato);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível criar o Candidato" });
            }
        }
    }
}
