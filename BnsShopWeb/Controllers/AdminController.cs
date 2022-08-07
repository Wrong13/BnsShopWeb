using BnsShopWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web;

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

    public async Task<IActionResult> Create()
    {
        return View("Edit", new Product());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Product product, IFormFile image = null)
    {
       
        if (ModelState.IsValid)
        {
            if (image != null)
            {
               
            }
            db.Update(product);
            await db.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    
    public async Task<IActionResult> Delete(int id)
    {
        Product delproduct = await db.Products.FirstOrDefaultAsync(x=>x.Id == id);
        if (delproduct == null) return NotFound();
        db.Remove(delproduct);
        db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    
}