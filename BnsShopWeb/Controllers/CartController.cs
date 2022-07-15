using BnsShopWeb.Models;
using Microsoft.AspNetCore.Mvc;


namespace BnsShopWeb.Controllers;

public class CartController : Controller
{
    private BnsContext db = new BnsContext();
    // GET
    public ViewResult Index(string returnUrl)
    {
        return View(new CartVM
        {
            Cart = GetCart(),
            ReturnUrl = returnUrl
        });
    }

    public RedirectToRouteResult AddToCart(int productId, string returnUrl)
    {
        Product product = db.Products.FirstOrDefault(x => x.Id == productId);
        if (product != null)
        {
            GetCart().AddItem(product, 1);
        }

        return RedirectToRoute("Index", new { returnUrl });
    }

    public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
    {
        Product product = db.Products.FirstOrDefault(x => x.Price == productId);
        if (product != null)
            GetCart().RemoveLine(product);
        return RedirectToRoute("Index", new {returnUrl});
    }
    
    public string CartData { get; set; }
    
    public Cart GetCart()
    {
        Cart cart = (Cart)Session["Cart"];
        if (cart == null)
        {
            cart = new Cart();
            Session["Cart"] = cart;
        }

        return cart;
    }
}