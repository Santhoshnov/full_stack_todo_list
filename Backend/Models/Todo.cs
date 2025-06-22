namespace Backend.Models
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsComplete { get; set; }
    }
}