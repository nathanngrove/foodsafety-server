namespace FSSA.Models
{
    public class Entry
    {
        public int EntryId { get; set; }
        public int? SubmittedBy { get; set; }
        public string? CleanUpLocation { get; set; }
        public DateTime? CompletedAt { get; set; } = DateTime.Now;
        public int StoreId { get; set; }
        public int ChecklistId { get; set; }
    }
}
