
public class ProductsRequest 
{
    public int ProductId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public int BrandId { get; set; }
    public int AccountId { get; set; }
    public int SizeId{get;set;}
    public List<ImageDTO> Images { get; set; }
}