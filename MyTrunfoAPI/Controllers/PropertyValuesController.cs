using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTrunfoAPI.Data;
using MyTrunfoAPI.Model;

namespace MyTrunfoAPI.Controllers
{
    [Route("api/property-values")]
    [ApiController]
    public class PropertyValuesController : ControllerBase
    {
        private readonly DataContext _context;

        public PropertyValuesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyValue>>> GetValues()
        {
            return await _context.PropertyValues.ToListAsync();
        }

        // GET: api/Values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyValue>> GetValue(int id)
        {
            var value = await _context.PropertyValues.FindAsync(id);

            if (value == null)
            {
                return NotFound();
            }

            return value;
        }

        // PUT: api/Values/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutValue(int id, PropertyValue value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }

            _context.Entry(value).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValueExists(id))
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

        // POST: api/Values
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PropertyValue>> PostValue(PropertyValue value)
        {
            _context.PropertyValues.Add(value);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetValue", new { id = value.Id }, value);
        }

        // DELETE: api/Values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteValue(int id)
        {
            var value = await _context.PropertyValues.FindAsync(id);
            if (value == null)
            {
                return NotFound();
            }

            _context.PropertyValues.Remove(value);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ValueExists(int id)
        {
            return _context.PropertyValues.Any(e => e.Id == id);
        }
    }
}
