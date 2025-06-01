namespace FSSA.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public required string DepartmentName { get; set; }

        public List<Store> Stores { get; } = [];
        public List<Checklist> Checklists { get; } = [];
    }
}
