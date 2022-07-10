using BnsShopWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BnsShopWeb.Controllers;

public class ProductsController : Controller
{
    private readonly BnsContext db;
    // GET
    public ProductsController(BnsContext context)
    {
        db = context;
    }
    public IActionResult Index()
    {
        return View(db.Products.ToList());
    }
}