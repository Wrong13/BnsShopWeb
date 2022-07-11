using BnsShopWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BnsShopWeb.Controllers;

public class ProductsController : Controller
{
    private readonly BnsContext db;
    // GET
    public ProductsController(BnsContext context)
    {
        db = context;
    }
    public async Task<IActionResult> Index()
    {
        return View(await db.Products.ToListAsync());
    }
}