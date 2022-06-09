public class ProductsDTO{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public List<string> ImagesUrl { get; set; }
    public string Status { get; set; }
    public AccountDTO Seller { get; set; }
}