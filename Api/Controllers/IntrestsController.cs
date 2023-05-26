using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models;
using AutoMapper;
using Api.Models.DTO;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntrestsController : ControllerBase
    {
        private readonly ApiDbContext _context;

        private readonly IMapper _mapper;
        public IntrestsController(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Intrests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Intrest>>> GetIntrests()
        {
          if (_context.Intrests == null)
          {
              return NotFound();
          }
            return await _context.Intrests.ToListAsync();
        }


        [HttpGet("PersonId")]
        public async Task<ActionResult<IEnumerable<Intrest>>> GetIntrests(int? personId)
        {
            if (_context.Intrests == null)
            {
                return NotFound();
            }

            var Intrests = _context.Intrests.AsQueryable();

            if (personId != null)
            {
                Intrests = Intrests.Where(i => i.FK_PersonId == personId);
            }


            return await Intrests.ToListAsync();
        }



        // GET: api/Intrests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Intrest>> GetIntrest(int id)
        {
          if (_context.Intrests == null)
          {
              return NotFound();
          }
            var intrest = await _context.Intrests.FindAsync(id);

            if (intrest == null)
            {
                return NotFound();
            }

            return intrest;
        }

        // PUT: api/Intrests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIntrest(int id, Intrest intrest)
        {
            if (id != intrest.IntrestId)
            {
                return BadRequest();
            }

            _context.Entry(intrest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntrestExists(id))
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

        // POST: api/Intrests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IntrestCreateDto>> PostIntrest(IntrestCreateDto intrestDto)
        {
          if (_context.Intrests == null)
          {
              return Problem("Entity set 'ApiDbContext.Intrests'  is null.");
          }

            var intrest = new Intrest
            {
                Title = intrestDto.Title,
                Description = intrestDto.Description,
                FK_PersonId = intrestDto.PersonId
            };

            _context.Intrests.Add(intrest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIntrest", new { id = intrest.IntrestId }, intrest);
        }

        // DELETE: api/Intrests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIntrest(int id)
        {
            if (_context.Intrests == null)
            {
                return NotFound();
            }
            var intrest = await _context.Intrests.FindAsync(id);
            if (intrest == null)
            {
                return NotFound();
            }

            _context.Intrests.Remove(intrest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IntrestExists(int id)
        {
            return (_context.Intrests?.Any(e => e.IntrestId == id)).GetValueOrDefault();
        }
    }
}
