using FSSA.Common;
using FSSA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FSSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public EntryController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Entry>> AddEntry(Entry entry)
        {
            if (entry == null) return BadRequest();

            _context.Entries.Add(entry);
            await _context.SaveChangesAsync();
            return Created();
        }

        [HttpGet]
        public async Task<ActionResult<Entry>> GetAllEntries()
        {
            var entries = await _context.Entries.ToListAsync();
            return Ok(entries);
        }

    }
}
