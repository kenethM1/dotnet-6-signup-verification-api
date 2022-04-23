namespace WebApi.Entities;

public class Product {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public List<Image> Images { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
}