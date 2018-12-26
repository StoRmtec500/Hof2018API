using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Schaf.Models;

namespace Schaf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AblammController : ControllerBase
    {
        private readonly AblammContext _context;

        public AblammController(AblammContext context)
        {
            _context = context;
        }

        // GET: api/Ablamm
        [HttpGet]
        public IEnumerable<Ablamm2018> Getablamm()
        {
            return _context.Ablamm2018;
        }

        [HttpGet("{schaf_nr}")]
        public IEnumerable<Ablamm2018> Getablamm1([FromRoute]string schaf_nr)
        {
            return _context.Ablamm2018.Where(s => s.schaf_nr == schaf_nr);
        }

        [HttpGet("{schaf_nr}/{lfd_nr}")]
        public IEnumerable<Ablamm2018> Getablamm1([FromRoute]string schaf_nr, int lfd_nr)
        {
            return _context.Ablamm2018.AsNoTracking().Where(s => s.schaf_nr == schaf_nr && s.lfd_nr == lfd_nr);
        }

        // PUT: api/Ablamm/5
        [HttpPut("{schaf_nr}")]
        public async Task<IActionResult> PutAblamm([FromRoute] string schaf_nr, [FromBody] Ablamm2018 ablamm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (schaf_nr != ablamm.schaf_nr)
            {
                return BadRequest();
            }

            
            _context.Entry(ablamm).State = EntityState.Modified;
            //_context.Ablamm2018.Update(ablamm);
            //_context.SaveChanges();

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AblammExists(schaf_nr))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Erfolgreich");
        }

        // POST: api/Ablamm
        [HttpPost]
        public async Task<IActionResult> PostAblamm([FromBody] Ablamm2018 ablamm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Ablamm2018.Add(ablamm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAblamm", new { id = ablamm.schaf_nr }, ablamm);
        }

        // DELETE: api/Ablamm/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAblamm([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ablamm = await _context.Ablamm2018.FindAsync(id);
            if (ablamm == null)
            {
                return NotFound();
            }

            _context.Ablamm2018.Remove(ablamm);
            await _context.SaveChangesAsync();

            return Ok(ablamm);
        }

        private bool AblammExists(string id)
        {
            return _context.Ablamm2018.Any(e => e.schaf_nr == id);
        }
    }
}