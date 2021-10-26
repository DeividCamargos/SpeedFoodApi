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
    public class PedidoController : ControllerBase
    {
        private readonly SpeedFoodContext _context;

        public PedidoController(SpeedFoodContext context)
        {
            _context = context;
        }

        // GET: api/Pedido
        [HttpGet]
        public async Task<ActionResult<List<Pedido>>> GetAvaliacoes()
        {
            try
            {
                var List = await _context.Pedidos.AsNoTracking().ToListAsync();

                return Ok(List);
            }   
            catch
            {
                return BadRequest(new { message = "Não foi possivel retornar nenhum pedido" });
            }
        }

        // GET: api/Pedido/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pedido>> GetAvaliacao(int id)
        {
            try
            {
                var pedido = await _context.Pedidos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (pedido == null)
                    return NotFound(new { message = "Id não encontrado" });

                return Ok(pedido);
            }
            catch 
            {
                return BadRequest(new { message = "Não foi Possível retornar o pedido" });
            } 
        }

        // POST: api/Pedido
        [HttpPost]
        public async Task<ActionResult<Pedido>> PostAvaliacao([FromBody] Pedido pedido)
        {
            pedido.Data = System.DateTime.Now;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _context.Pedidos.Add(pedido);
                await _context.SaveChangesAsync();

                return Ok(); 
            }
            catch (System.Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o pedido" });
            }
        }
    }
}
