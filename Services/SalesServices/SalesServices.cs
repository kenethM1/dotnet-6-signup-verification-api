using WebApi.Helpers;

public class SaleService : ISalesService
{
    private readonly DataContext _context;
    public SaleService(DataContext context){
        _context = context;
    }

    public OrdersResponse GetMyOrders(string userId){
        if(string.IsNullOrEmpty(userId)){
            return new OrdersResponse{
                Message = "UserId is required",
                Success = false
            };
        }
        var myPurchases = GetPurchases(userId);
        var mySales = GetSales(userId);

        return new OrdersResponse{
            Message = "Success",
            Success = true,
            MyPurchases = myPurchases,
            MySales = mySales
        };    
    }

    private List<ProductsDTO> GetSales(string userId)
    {
        return _context.Products.Where(s => s.AccountId == int.Parse(userId)).Select
        (
            e=> new ProductsDTO
            {
                Id = e.Id,
                Name = e.Title,
                Description = e.Description,
                Price = e.Price,
                ImagesUrl = e.Images.Select(x=>x.Url).ToList(),
                Status = e.Sale.Status,
                Seller = new AccountDTO{
                    Id = e.Account.Id,
                    FirstName = e.Account.FirstName,
                    LastName = e.Account.LastName, 
                    PhoneNumber = e.Account.SaleForm.Phone,
                    ProfilePicture = e.Account.ProfilePicture,  
            }}
        ).ToList();
    }

    private List<ProductsDTO> GetPurchases(string userId)
    {
        return _context.Products.Where(x => x.Sale.SellerId == int.Parse(userId) ).Select(
            e=> new ProductsDTO{
                Id = e.Id,
                Name = e.Title,
                Description = e.Description,
                Price = e.Price,
                ImagesUrl = e.Images.Select(x=>x.Url).ToList(),
                Status = e.Sale.Status,
                Seller = new AccountDTO{
                    Id = e.Account.Id,
                    FirstName = e.Account.FirstName,
                    LastName = e.Account.LastName, 
                    PhoneNumber = e.Account.SaleForm.Phone,
                    ProfilePicture = e.Account.ProfilePicture,    
                }
            }
        ).ToList();
    }
}