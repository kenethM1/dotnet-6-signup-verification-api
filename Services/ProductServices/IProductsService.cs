using WebApi.Entities;
public interface IProductsService {
    List<ProductResponse> GetAll();
    ProductResponse CreateProduct(ProductsRequest request);
    ProductResponse RemoveProduct(int id);
    List<ProductResponse> GetProductByCategory(int id);
    List<SizeDTO> GetAllSizes();
    List<SizeDTO> InsertListSizes(SizeRequest request);
    BrandResponse GetAllBrands();
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