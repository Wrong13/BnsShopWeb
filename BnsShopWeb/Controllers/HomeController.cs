using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BnsShopWeb.Models;

namespace BnsShopWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        using (BnsContext db = new BnsContext())
        {
            db.Products.Add(new Product { Title = "title", Type = "Type", Price = 100 });
            db.SaveChanges();
        }
        
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}