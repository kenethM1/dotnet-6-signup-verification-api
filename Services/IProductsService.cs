using WebApi.Entities;
public interface IProductsService {
    IEnumerable<Product> GetAll();
    Product GetById(int id);
    Product Create(CreateRequest model);
    Product Update(int id, UpdateRequest model);
    void Delete(int id);
    
}

public class CreateRequest {
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
}

public class UpdateRequest {
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
}