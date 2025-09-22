using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookstore.Models;
using bookstore.ViewModels;
using bookstore.Data;
using Microsoft.EntityFrameworkCore;
namespace bookstore.Controllers;

public class UsersController : Controller
{
    private readonly ILogger<UsersController> _logger;
    private readonly DBContext _context;
    public UsersController(ILogger<UsersController> logger, DBContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        IList<User> Users = await _context.Users.ToListAsync();
        UsersViewModel ViewModel = new UsersViewModel { Users = Users };
        return View(ViewModel);
    }
    [HttpPost]
    public async Task<IActionResult> AddUser([Bind("FirstName,LastName,Email")] User user)
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
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> UpdateUser([Bind("Id,FirstName,LastName,Email")] User user)
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
        _context.Attach(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
    
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index");
    }
}