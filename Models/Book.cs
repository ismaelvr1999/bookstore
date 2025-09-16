using System.ComponentModel.DataAnnotations;

namespace bookstore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public int? PublicationYear { get; set; }
        public int AutorId { get; set; }
        public Autor? Autor { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}