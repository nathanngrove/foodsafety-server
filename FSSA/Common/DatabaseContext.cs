using FSSA.Models;
using Microsoft.EntityFrameworkCore;

namespace FSSA.Common
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {}
        
        public DbSet<Store> Stores { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<Entry> Entries { get; set; }
    }
}
