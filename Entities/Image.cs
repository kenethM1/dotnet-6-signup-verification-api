using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities;

public class Image {
    [Key]
[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public string Description { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }

    internal ImageDTO FromEntity()
    {
        return new ImageDTO
        {
            Id = this.Id,
            Url = this.Url,
            ProductId = this.ProductId
        };
    }
}