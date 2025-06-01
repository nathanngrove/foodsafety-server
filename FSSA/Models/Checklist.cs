namespace FSSA.Models
{
    public class Checklist
    {
        public int ChecklistId { get; set; } 
        public required string ChecklistTitle { get; set; }
        public required string ChecklistType { get; set; }
        public int DepartmentId { get; set; }

        public ICollection<Entry> Entries { get; } = [];
    }
}
