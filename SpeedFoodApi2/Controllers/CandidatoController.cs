﻿using System;
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
    public class CandidatoController : ControllerBase
    {
        private readonly SpeedFoodContext _context;

        public CandidatoController(SpeedFoodContext context)
        {
            _context = context;
        }

        // GET: api/Candidato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidato>>> GetCandidatos()
        {
            return await _context.Candidatos.ToListAsync();
        }

        // GET: api/Candidato/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Candidato>> GetCandidato(int id)
        {
            var candidato = await _context.Candidatos.FindAsync(id);

            if (candidato == null)
            {
                return NotFound();
            }

            return candidato;
        }

        // PUT: api/Candidato/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidato(int id, Candidato candidato)
        {
            if (id != candidato.Id)
            {
                return BadRequest();
            }

            _context.Entry(candidato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoExists(id))
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

        // POST: api/Candidato
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Candidato>> PostCandidato(Candidato candidato)
        {
            _context.Candidatos.Add(candidato);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCandidato), new { id = candidato.Id }, candidato);
        }

        // DELETE: api/Candidato/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidato(int id)
        {
            var candidato = await _context.Candidatos.FindAsync(id);
            if (candidato == null)
            {
                return NotFound();
            }

            _context.Candidatos.Remove(candidato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CandidatoExists(int id)
        {
            return _context.Candidatos.Any(e => e.Id == id);
        }
    }
}