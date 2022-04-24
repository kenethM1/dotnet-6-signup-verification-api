public class Category{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }

    internal CategoriesDTO FromEntity()
    {
        return new CategoriesDTO {
            Id = this.Id,
            Title = this.Title,
            Description = this.Description,
            ImageUrl = this.ImageUrl
        };
    }
}