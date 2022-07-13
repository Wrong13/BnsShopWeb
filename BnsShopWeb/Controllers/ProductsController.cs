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

    public IActionResult List(int page = 1)
    {
        ProductsListVM productsListVm = new ProductsListVM
        {
            Products = db.Products.OrderBy(x=>x.Id)
                .Skip((page-1)*4).Take(4),
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = 4,
                TotalItems = db.Products.ToList().Count
            }
        };
        return View(productsListVm);
    }
}