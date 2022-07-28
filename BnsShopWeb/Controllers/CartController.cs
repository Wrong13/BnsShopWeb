using BnsShopWeb.Models;
using Microsoft.AspNetCore.Mvc;
using SessionExtensions = Microsoft.AspNetCore.Http.SessionExtensions;


namespace BnsShopWeb.Controllers;

public class CartController : Controller
{
    private BnsContext db = new BnsContext();
    // GET
    public ViewResult Index(string returnUrl)
    {
        return View(new CartIndexVM()
        {
            Cart = GetCart(),
            ReturnUrl = returnUrl
        });
    }

    [HttpPost]
    public async Task CartAdd(int productId)
    {
        Product product = db.Products.FirstOrDefault(x => x.Id == productId);
        if (product != null)
        {
            GetCart().AddItem(product, 1);
        }
    }
    
    public RedirectToRouteResult AddToCart(int productId)
    {
        Product product = db.Products.FirstOrDefault(x => x.Id == productId);
        if (product != null)
        {
            GetCart().AddItem(product, 1);
        }

        return RedirectToRoute("Index");
    }

    public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
    {
        Product product = db.Products.FirstOrDefault(x => x.Price == productId);
        if (product != null)
            GetCart().RemoveLine(product);
        return RedirectToRoute("Index", new {returnUrl});
    }
    
    public string CartData { get; set; }
    
    // Сделать сссию
    public Cart GetCart()
    {
        Cart cart = HttpContext.Session.Get<Cart>("Cart");
        if (cart == null)
        {
            cart = new Cart();
            HttpContext.Session.Set<Cart>("Cart",cart);
        }

        return cart;
    }
}