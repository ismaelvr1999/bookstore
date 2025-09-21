using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookstore.Models;
using bookstore.ViewModels;
using bookstore.Data;
using Microsoft.EntityFrameworkCore;
namespace bookstore.Controllers;

public class BooksController : Controller
{
    private readonly ILogger<BooksController> _logger;
    private readonly DBContext _context;
    public BooksController(ILogger<BooksController> logger, DBContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        IList<Book> Books = await _context.Books.Include(b => b.Autor).ToListAsync();
        BooksViewModel viewModel = new BooksViewModel{ Books = Books };
        return View(viewModel);
    }
    [HttpPost]
    public async Task<IActionResult> AddBook([Bind("Title,Description,PublicationYear,AutorId")] Book book)
    {
        if (!ModelState.IsValid)
        {

            foreach (var entry in ModelState)
            {
                foreach (var error in entry.Value.Errors)
                {
                    Console.WriteLine($"Field: {entry.Key}, Error: {error.ErrorMessage}");
                }
            }
            return RedirectToAction("Index");

        }
        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}