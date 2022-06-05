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
        CurrencyId = 1,
        AccountId = request.AccountId,
        Images = request.Images.Select(x => new Image
        {
            Title = request.Title,
            Url = x.Url,
            Updated = DateTime.Now,
            Created = DateTime.Now
        }).ToList(),
        SizeId = request.SizeId,
        Created = DateTime.Now,
        Updated = DateTime.Now
    };
    _context.Products.Add(product);
    _context.SaveChanges();

    var newProduct = _context.Products.Include(x => x.Category).Include(x => x.Brand).Include(x => x.Account).Include(x=>x.Size).FirstOrDefault(x => x.Id == product.Id);

    return newProduct.FromEntity();
}
    public List<ProductResponse> GetProductByCategory(int id)
    {
        var products = _context.Products.Where(e=>e.CategoryId == id).Include(x => x.Category).Include(x => x.Brand).Include(x => x.Account).Include(e=>e.Images).Where(x => x.CategoryId == id).ToList();
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
    public List<SizeDTO> GetAllSizes(){
        var sizes = _context.Size.Select(e=>e.toDto()).Distinct().ToList();
        return sizes;
    }
    public List<SizeDTO> InsertListSizes(SizeRequest request)
    {
        if(request ==null)
        {
            return new List<SizeDTO>{
                new SizeDTO{
                    Message = "NullValues"
                }
            };       
        }
        var notAllowedSizes = new List<string>();
        var addedSizes = new List<string>();
        foreach(string size in request.Size)
        {
            var existSizeInDatabase = _context.Size.FirstOrDefault(e=>e.Name == size);
            if(existSizeInDatabase !=null)
            {
                notAllowedSizes.Add(existSizeInDatabase.Name);
            }
            if(existSizeInDatabase == null)
            {
                _context.Size.Add(new Size{Name=size});
                addedSizes.Add(size);               
            }
        }
        _context.SaveChanges();
        return _context.Size.Select(e=>e.toDto()).ToList();
    }
    
    public BrandResponse GetAllBrands()
    {
        var response = new BrandResponse();
        var result = _context.Brand.Select(e=>e.FromEntity()).Distinct().ToList();
        response.Brands = result.ToList();
        return response;
    }
}