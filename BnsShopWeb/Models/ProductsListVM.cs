namespace BnsShopWeb.Models;

public class ProductsListVM
{
    public IEnumerable<Product> Products { get; set; }
    public PagingInfo PagingInfo { get; set; }
}