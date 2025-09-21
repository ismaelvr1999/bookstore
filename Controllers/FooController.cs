using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookstore.Models;
using bookstore.Data;
namespace bookstore.Controllers;
public class FooController : Controller
{
    private readonly ILogger<FooController> _logger;
    public FooController(ILogger<FooController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}