using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;
using WebApi.Entities;

public class ProductsService : IProductsService
{
    private readonly DataContext _context;
    public ProductsService(DataContext context)
    {
        _context = context;
    }

    public List<ProductResponse> GetAll()
    {
        var products = _context.Products.Include(x => x.Category).Include(x => x.Brand).Include(x => x.Account).Include(e=>e.Images).ToList();
        var response = products.Select(x => new ProductResponse
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            Price = x.Price,
            Category = x.Category.FromEntity(),
            Brand = x.Brand.FromEntity(),
            SellerAccount = x.Account.FromEntity(),
            SellerAccountId = x.Account.Id,
            Updated = x.Updated,
            Images = x.Images.Select(i => i.FromEntity()).ToList()
        }).ToList();
        return response;
    }

public ProductResponse CreateProduct(ProductsRequest request)
{
    var product = new Product
    {
        Title = request.Title,
        Description = request.Description,
        Price = request.Price,
        CategoryId = request.CategoryId,
        BrandId = request.BrandId,
        AccountId = request.AccountId,
        Images = request.Images.Select(x => new Image
        {
            Title = request.Title,
            Url = x.Url,
            Updated = DateTime.Now,
            Created = DateTime.Now
        }).ToList(),
        Created = DateTime.Now,
        Updated = DateTime.Now
    };
    _context.Products.Add(product);
    _context.SaveChanges();

    var newProduct = _context.Products.Include(x => x.Category).Include(x => x.Brand).Include(x => x.Account).FirstOrDefault(x => x.Id == product.Id);

    return newProduct.FromEntity();
}

    public ProductResponse RemoveProduct(int id)
    {
        var product = _context.Products.Include(x => x.Category).Include(x => x.Brand).Include(x => x.Account).FirstOrDefault(x => x.Id == id);
        if (product == null)
        {
            return null;
        }
        _context.Products.Remove(product);
        _context.SaveChanges();
        return product.FromEntity();
    }
    
}