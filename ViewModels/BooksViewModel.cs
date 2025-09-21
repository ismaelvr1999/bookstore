using bookstore.Models;
using System.Collections.Generic;
namespace bookstore.ViewModels;

public class BooksViewModel
{
    public IList<Book> Books { get; set; } = default!;
    public Book Book { get; set; } = default!;
}