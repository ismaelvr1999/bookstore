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
namespace bookstore.Pages.Users;

public class IndexModel : PageModel
{
    private readonly DBContext _context;
    public IList<User>? Users { get; set; }
    [BindProperty]
    public User? NewUser { get; set; } = default!;
    public IndexModel(DBContext context)
    {
        _context = context;
    }

    public async Task OnGetAsync()
    {
        Users = await _context.Users.ToListAsync();
    }

    public async Task<IActionResult> OnPostAddUserAsync()
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
        if (User != null)
        {
            _context.Users.Add(NewUser);
            await _context.SaveChangesAsync();
        }


        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteUserAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return RedirectToPage();
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostUpdateUserAsync()
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

        _context.Attach(this.NewUser).State = EntityState.Modified; ;
        await _context.SaveChangesAsync();

        return RedirectToPage();
    }
}