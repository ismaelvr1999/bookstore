using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using bookstore.Data;
using bookstore.Models;
namespace bookstore.Pages;

public class IndexModel : PageModel
{
    private readonly DBContext _context;
    public IList<Book> Books { get; set; } = default!;
    [BindProperty]
    public Book Book { get; set; } = default!;

    public IndexModel(DBContext context)
    {
        _context = context;
    }
    public async Task OnGetAsync()
    {
        Books = await _context.Books.Include(b => b.Autor).ToListAsync();
    }
    public async Task<IActionResult> OnPostAddBookAsync()
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
            return Page();

        }
        _context.Books.Add(Book);
        await _context.SaveChangesAsync();

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage();
    }
}


