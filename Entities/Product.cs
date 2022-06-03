using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities;

public class Product {
    [Key]
[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public List<Image> Images { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
    public int AccountId { get; set; } 
    public Account Account { get; set; }
    public Size Size {get;set;}
    public int SizeId {get;set;}
    public decimal Stars {get;set;}
    public int CurrencyId {get;set;}
    public Currency Currency {get;set;}
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }

    internal ProductResponse FromEntity()
    {
        return new ProductResponse
        {
            Id = this.Id,
            Title = this.Title,
            Description = this.Description,
            Price = this.Price,
            CategoryId = this.CategoryId,
            Category = this.Category.FromEntity(),
            BrandId = this.BrandId,
            Brand = this.Brand.FromEntity(),
            Images = Images != null ? this.Images.Select(i => i.FromEntity()).ToList() : new List<ImageDTO>(),
            Size = Size.toDto(),
            Updated = this.Updated
        };
    }
}