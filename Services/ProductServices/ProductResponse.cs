public class ProductResponse : ResponseBase
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public List<ImageDTO> Images { get; set; }
    public int CategoryId { get; set; }
    public CategoriesDTO Category { get; set; }
    public int BrandId { get; set; }
    public BrandDTO Brand { get; set; }
    public int SellerAccountId { get; set; }
    public AccountDTO SellerAccount { get; set; }
    public DateTime? Updated { get; set; }
}