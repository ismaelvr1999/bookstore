using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookstore.Models;
using bookstore.ViewModels;
using bookstore.Data;
using Microsoft.EntityFrameworkCore;
namespace bookstore.Controllers;

public class AutorsController : Controller
{
    private readonly ILogger<AutorsController> _logger;
    private readonly DBContext _context;
    public AutorsController(ILogger<AutorsController> logger, DBContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        IList<Autor> Autors = await _context.Autors.ToListAsync();
        AutorsViewModel ViewModel = new AutorsViewModel { Autors = Autors };
        return View(ViewModel);
    }
    [HttpPost]
    public async Task<IActionResult> AddAutor([Bind("FirstName,LastName,Biography")] Autor autor)
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
        _context.Autors.Add(autor);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> UpdateAutor([Bind("Id,FirstName,LastName,Biography")] Autor autor)
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
        _context.Attach(autor).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
    
    public async Task<IActionResult> DeleteAutor(int id)
    {
        var autor = await _context.Autors.FindAsync(id);

        if (autor != null)
        {
            _context.Autors.Remove(autor);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index");
    }
}