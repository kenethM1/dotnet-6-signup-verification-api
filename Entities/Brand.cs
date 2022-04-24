public class Brand {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }

    internal BrandDTO FromEntity()
    {
        return new BrandDTO {
            Id = this.Id,
            Name = this.Title
        };
    }
}