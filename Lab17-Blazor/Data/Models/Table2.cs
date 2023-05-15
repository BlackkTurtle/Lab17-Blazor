namespace Lab17_Blazor.Data.Models
{
    public class Table2
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Table1Id { get; set; }
        public virtual Table1 Table1 { get; set; } = null!;
    }
}
