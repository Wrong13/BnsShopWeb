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
    
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();
        var product = await db.Products.FindAsync(id);
        if (product == null) return NotFound();
        return View(product);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Type,Price,ImageData,ImageMimeType")] Product product)
    {
        if (id != product.Id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            db.Update(product);
            await db.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}