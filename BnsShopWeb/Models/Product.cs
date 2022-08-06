using System.ComponentModel.DataAnnotations;

namespace BnsShopWeb.Models;

public class Product
{
    public int Id { get; set; }
    [Display(Name="��������")]
    public string Title { get; set; }
    [Display(Name = "���")]
    public string Type {get; set; }
    [Display(Name = "����")]
    public decimal Price { get; set; }
    
    public byte[]? ImageData { get; set; }
    public string? ImageMimeType { get; set; }
}