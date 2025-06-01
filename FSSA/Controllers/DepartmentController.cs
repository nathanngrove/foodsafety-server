using FSSA.Common;
using FSSA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FSSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public DepartmentController(DatabaseContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetAllDepartments()
        {
            var departments = await _context.Departments.AsNoTracking().ToListAsync();
            if (departments == null) return NoContent();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            if (id < 0) return BadRequest();

            var department = await _context.Departments.AsNoTracking().FirstOrDefaultAsync(d => d.DepartmentId == id);
            if (department == null) return NotFound();

            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult<Department>> AddDepartment(Department department)
        {
            if (department == null) return BadRequest();

            department.DepartmentName = department.DepartmentName.ToLower().Replace(" ", "-");

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Department>> UpdateDepartment(int id, Department department)
        {
            if (department == null) return BadRequest();

            var departmentToUpdate = _context.Departments.Find(id);
            if (departmentToUpdate == null) return NotFound();

            string departmentNameLowerCaseNoSpaces = department.DepartmentName.ToLower().Replace(" ", "-");

            departmentToUpdate.DepartmentName = departmentNameLowerCaseNoSpaces;
            await _context.SaveChangesAsync();
            return Ok(department);
        }

        [HttpGet("{id}/checklists")]
        public async Task<ActionResult<List<Checklist>>> GetChecklistsInDepartment(int id)
        {
            if (id < 0) return BadRequest();

            var checklists = await _context.Checklists.AsNoTracking().Where(d => d.DepartmentId == id).ToListAsync();
            if (checklists.IsNullOrEmpty()) return NotFound();

            return Ok(checklists);
        }
    }
}
