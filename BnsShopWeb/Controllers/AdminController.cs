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
    public async Task<IActionResult> Edit([Bind("Id,Title,Type,Price,ImageData,ImageMimeType")]Product product, IFormFile image = null)
    {
       
        if (ModelState.IsValid)
        {
            if(image.Length>0)
            {
                byte[] p1 = null;
                using (var fs1 = image.OpenReadStream()) 
                using (var ms1 = new MemoryStream())
                {
                    fs1.CopyTo(ms1);
                    p1 = ms1.ToArray();
                }
                product.ImageData = p1;
            }
            if (db.Products.FirstOrDefaultAsync(x => x.Id == product.Id) != null)
                db.Update(product);
            else await db.Products.AddAsync(product);
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