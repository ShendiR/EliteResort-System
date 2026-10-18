using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EliteResort.API.Data;
using EliteResort.API.Models;

namespace EliteResort.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AeroportiController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AeroportiController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmriPrind>>> GetPrinderit() =>
            await _context.EmriPrinderit.Include(p => p.EmriFemijet).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<EmriPrind>> GetPrindi(int id)
        {
            var prindi = await _context.EmriPrinderit.FindAsync(id);
            return prindi == null ? NotFound() : prindi;
        }

        [HttpPost]
        public async Task<ActionResult<EmriPrind>> PostPrind(EmriPrind prind)
        {
            _context.EmriPrinderit.Add(prind);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPrinderit), new { id = prind.Id }, prind);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrind(int id, EmriPrind prind)
        {
            if (id != prind.Id) return BadRequest();
            _context.Entry(prind).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrind(int id)
        {
            var prind = await _context.EmriPrinderit.FindAsync(id);
            if (prind == null) return NotFound();
            _context.EmriPrinderit.Remove(prind); 
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}