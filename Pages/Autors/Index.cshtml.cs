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
namespace bookstore.Pages.Autors;

public class IndexModel : PageModel
{
    private readonly DBContext _context;
    public IList<Autor>? Autors { get; set; }
    [BindProperty]
    public Autor? Autor { get; set; } = default!;
    public IndexModel(DBContext context)
    {
        _context = context;
    }

    public async Task OnGetAsync()
    {
        Autors = await _context.Autors.ToListAsync();
    }

    public async Task<IActionResult> OnPostAddAsync()
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
        if (Autor == null)
        {
            return RedirectToPage();
        }
        _context.Autors.Add(Autor);
        await _context.SaveChangesAsync();

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteAutorAsync(int id)
    {
        var autor = await _context.Autors.FindAsync(id);

        if (autor == null)
        {
            return RedirectToPage();
        }
        
        _context.Autors.Remove(autor);
        await _context.SaveChangesAsync();
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostUpdateAutorAsync()
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

        _context.Attach(this.Autor).State = EntityState.Modified; ;
        await _context.SaveChangesAsync();

        return RedirectToPage();
    }
}