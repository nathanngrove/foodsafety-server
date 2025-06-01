using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using FSSA.Common;
using FSSA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FSSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public StoreController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Store>>> GetAllStores()
        {
            var stores = await _context.Stores.AsNoTracking().ToListAsync();
            if (stores == null) return NoContent();
            return Ok(stores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Store>> GetStore(int id)
        {
            if (id < 0) return BadRequest();

            var store = await _context.Stores.AsNoTracking().FirstOrDefaultAsync(s => s.StoreId == id);
            if (store == null) return NotFound();

            return Ok(store);
        }

        [HttpPost]
        public async Task<ActionResult<Store>> AddStore(Store store)
        {
            if (store == null) return BadRequest();

            _context.Stores.Add(store);
            await _context.SaveChangesAsync();
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Store>> AddDepartmentsToStore(int id, List<int> departmentIds)
        {
            if (departmentIds == null || departmentIds.Count == 0) return BadRequest();
            if (id < 0) return BadRequest();

            var store = await _context.Stores.FindAsync(id);
            if (store == null) return NotFound();

            departmentIds.ForEach(async (depId) => {
                var department = await _context.Departments.AsNoTracking().FirstOrDefaultAsync(d => d.DepartmentId == depId);
                if (department != null) store.Departments.Add(department);
            });

            await _context.SaveChangesAsync();
            return Ok();
        }   

        [HttpGet("{id}/departments")]
        public async Task<ActionResult<List<Department>>> GetDepartmentsAtStore(int id)
        {
            if (id < 0) return BadRequest();

            var departmentsInStore = await _context.Departments.AsNoTracking().Where(d => d.Stores.Any(s => s.StoreId == id)).ToListAsync();
            if (departmentsInStore == null) return NotFound();

            return Ok(departmentsInStore);
        }
    }
}
