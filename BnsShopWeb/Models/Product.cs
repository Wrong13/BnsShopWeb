namespace BnsShopWeb.Models;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; }
    public  string Type {get; set; }
    public decimal Price { get; set; }
    
    public byte[]? ImageData { get; set; }
    public string? ImageMimeType { get; set; }
}