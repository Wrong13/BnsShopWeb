namespace BnsShopWeb.Models;

public class Cart
{
    private List<CartLine> lineCollection = new List<CartLine>();

    public void AddItem(Product product, int quantity)
    {
        CartLine line = lineCollection.Where(x => x.Product.Id == product.Id).FirstOrDefault();
        if (line == null)
        {
            lineCollection.Add(new CartLine
            {
                Product = product,
                Quantity = quantity
            });
        }
        else
            line.Quantity += quantity;
    }

    public void RemoveLine(Product product)
    {
        lineCollection.RemoveAll(x => x.Product.Id == product.Id);
    }

    public decimal ComputeTotalValue()
    {
        return lineCollection.Sum(x => x.Quantity * x.Product.Price);
    }

    public void Clear()
    {
        lineCollection.Clear();
    }

    public IEnumerable<CartLine> Lines
    {
        get { return lineCollection; }
    }
    
}
public class CartLine
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
}