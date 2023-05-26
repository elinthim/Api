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
    public class LinksController : ControllerBase
    {

        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;
        public LinksController(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

     

        // GET: api/Links
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Link>>> GetLinks()
        {
          if (_context.Links == null)
          {
              return NotFound();
          }
            return await _context.Links.ToListAsync();
        }

        [HttpGet("Link by PersonId")]
        public async Task<ActionResult<IEnumerable<Link>>> GetLinks(int personId)
        {
            var links = await _context.Links
            .Include(l => l.Intrest)
            .Include(l => l.Intrest.Person)
            .Where(l => l.Intrest.Person.PersonId == personId)
            .ToListAsync();

            if (links == null)
            {
                return NotFound();
            }

            return links;
        }

        // GET: api/Links/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Link>> GetLink(int id)
        {
          if (_context.Links == null)
          {
              return NotFound();
          }
            var link = await _context.Links.FindAsync(id);

            if (link == null)
            {
                return NotFound();
            }

            return link;
        }

        // PUT: api/Links/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLink(int id, Link link)
        {
            if (id != link.LinkId)
            {
                return BadRequest();
            }

            _context.Entry(link).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinkExists(id))
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

        // POST: api/Links
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LinkCreateDto>> PostIntrest(LinkCreateDto linkCreate)
        {
          if (_context.Links == null)
          {
              return Problem("Entity set 'ApiDbContext.Links'  is null.");
          }

            var link = new Link
            {
                Url = linkCreate.Url,
                FK_IntrestId = linkCreate.IntrestId
            };

            _context.Links.Add(link);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLink", new { id = linkCreate.IntrestId }, linkCreate);
        }

        // DELETE: api/Links/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLink(int id)
        {
            if (_context.Links == null)
            {
                return NotFound();
            }
            var link = await _context.Links.FindAsync(id);
            if (link == null)
            {
                return NotFound();
            }

            _context.Links.Remove(link);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LinkExists(int id)
        {
            return (_context.Links?.Any(e => e.LinkId == id)).GetValueOrDefault();
        }
    }
}
