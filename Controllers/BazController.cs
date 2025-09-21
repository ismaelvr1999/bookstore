using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookstore.Models;
using bookstore.Data;
namespace bookstore.Controllers;
public class BazController : Controller
{
    private readonly ILogger<FooController> _logger;
    public BazController(ILogger<FooController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}