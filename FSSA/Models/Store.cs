namespace FSSA.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        public required string StoreName { get; set; }
        public required int StoreNumber { get; set; }

        public List<Department> Departments { get; } = [];
        public List<Entry> Entries { get; } = [];
    }
}
