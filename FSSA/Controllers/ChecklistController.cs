using FSSA.Common;
using FSSA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FSSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChecklistController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ChecklistController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Checklist>> GetChecklist(int id)
        {
            if (id < 0) return BadRequest();

            var checklist = await _context.Checklists.AsNoTracking().FirstOrDefaultAsync(c => c.ChecklistId == id);
            if (checklist == null) return NotFound();

            return Ok(checklist);
        }

        [HttpGet]
        public async Task<ActionResult<List<Checklist>>> GetAllChecklists()
        {
            var checklists = await _context.Checklists.AsNoTracking().ToListAsync();
            if (checklists == null) return NoContent();
            return Ok(checklists);
        }

        [HttpPost]
        public async Task<ActionResult<Checklist>> AddChecklist(Checklist checklist)
        {
            if (checklist == null) return BadRequest();

            Department? department = await _context.Departments.AsNoTracking().FirstOrDefaultAsync(d => d.DepartmentId == checklist.DepartmentId);
            if (department == null) return BadRequest();

            _context.Checklists.Add(checklist);

            await _context.SaveChangesAsync();
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Checklist>> UpdateChecklist(int id, Checklist newChecklist)
        {
            if (id < 0) return BadRequest();
            if (newChecklist == null) return BadRequest();

            var checklist = await _context.Checklists.FindAsync(id);
            if (checklist == null) return NotFound();

            Department? department = await _context.Departments.AsNoTracking().FirstOrDefaultAsync(d => d.DepartmentId == checklist.DepartmentId);
            if (department == null) return BadRequest();

            checklist.ChecklistTitle = newChecklist.ChecklistTitle;
            checklist.ChecklistType = newChecklist.ChecklistType;
            checklist.DepartmentId = newChecklist.DepartmentId;

            await _context.SaveChangesAsync();
            return Ok(newChecklist);
        }
    }
}
