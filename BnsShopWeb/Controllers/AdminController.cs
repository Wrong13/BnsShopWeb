using BnsShopWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BnsShopWeb.Controllers;

public class AdminController : Controller
{
    BnsContext db;

    public AdminController()
    {
        db = new BnsContext();
    }
    public IActionResult Index()
    {
        return View(db.Products);
    }
}