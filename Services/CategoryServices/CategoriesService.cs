using AutoMapper;
using WebApi.Authorization;
using WebApi.Helpers;
using WebApi.Services;

public class CategoriesService : ICategoriesService
{
    private readonly DataContext _context;
    private readonly IJwtUtils _jwtUtils;

    public CategoriesService(DataContext context, IJwtUtils jwtUtils)
    {
        _context = context;
        _jwtUtils = jwtUtils;
    }
    public List<CategoriesDTO> GetAll()
    {
        var categories = _context.Categories.ToList();
        
        return MaterializeCategories(categories);
    }

    private List<CategoriesDTO> MaterializeCategories(IEnumerable<Category> categories)
    {
       return categories.Select(c => new CategoriesDTO
        {
            Id = c.Id,
            Title = c.Title,
            Description = c.Description,
             ImageUrl = c.ImageUrl,
             Message = Statuses.Success
        }).ToList();
    }

    public CategoriesDTO GetById(int id)
    {
        Category category = _context.Categories.Find(id);
        if (category == null)
        {
            return null;
        }
        return new CategoriesDTO
        {
            Id = category.Id,
            Title = category.Title,
            Description = category.Description,
            ImageUrl = category.ImageUrl,
            Success = true,
            Message = Statuses.Success
        };
    }
    
    public CategoriesDTO Create(CategoryRequest model)
    {
        Category category = new Category
        {
            Title = model.Title,
            Description = model.Description,
            Created = DateTime.Now,
            Updated = DateTime.Now,
            ImageUrl = model.ImageUrl
        };
        _context.Categories.Add(category);
        _context.SaveChanges();
        return new CategoriesDTO
        {
            Id = category.Id,
            Title = category.Title,
            Description = category.Description,
            ImageUrl = category.ImageUrl,
            Success = true,
            Message = Statuses.Success
        };
    }

public CategoriesDTO Update(int id, CategoryRequest model){
        Category category = _context.Categories.Find(id);
        if (category == null)
        {
            return null;
        }
        category.Title = model.Title;
        category.Description = model.Description;
        category.Updated = DateTime.Now;
        category.ImageUrl = model.ImageUrl;
        _context.SaveChanges();
        return new CategoriesDTO
        {
            Id = category.Id,
            Title = category.Title,
            Description = category.Description,
            ImageUrl = category.ImageUrl,
            Success = true,
            Message = Statuses.Success
        };
    }
    public CategoriesDTO Delete(int id){
        Category category = _context.Categories.Find(id);
        if (category == null)
        {
            return new CategoriesDTO{
                Success = false,
                Message = Statuses.NotFound
            };
        }
        _context.Categories.Remove(category);
        _context.SaveChanges();
        return new CategoriesDTO
        {
            Id = category.Id,
            Title = category.Title,
            Description = category.Description,
            ImageUrl = category.ImageUrl,
            Success = true,
            Message = Statuses.Success
        };
    }
}