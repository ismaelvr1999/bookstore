namespace bookstore.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string? Biography { get; set; } 
        public ICollection<Book>? Books { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}