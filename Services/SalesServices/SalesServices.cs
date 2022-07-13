using Microsoft.EntityFrameworkCore;
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
        return _context.Products.Where(x => x.Sale.Sale.CustomerId == int.Parse(userId) ).Select(
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

    public OrdersResponse GetUnpaidSales(int userId)
    {
        var user = _context.Accounts.FirstOrDefault(e=>e.Id == userId);
        if(user== null)
        {
            return new OrdersResponse
            {
               Message = "User doesn't exists."
            };
        }
        var sales = user.Products.Where(e=>e.IsSelled && e.Sale.Status==Statuses.Delivered);

        return new OrdersResponse{
            MySales = sales.Select(e=> new ProductsDTO{
                Description = e.Description,
                ImagesUrl = e.Images.Select(d=>d.Url).ToList(),
                Name = e.Title,
                Price = e.Price,                
            }).ToList()
        };
    }
    public OrdersResponse UpdateOrderStatus(string userId, string orderId){
        if(string.IsNullOrEmpty(userId)){
            return new OrdersResponse{
                Message = "UserId is required",
                Success = false
            };
        }
        if(string.IsNullOrEmpty(orderId)){
            return new OrdersResponse{
                Message = "OrderId is required",
                Success = false
            };
        }
        var order = _context.Products.Include(x=>x.Sale).FirstOrDefault(x=>x.Id == int.Parse(orderId));
        if(order == null){
            return new OrdersResponse{
                Message = "Order not found",
                Success = false
            };
        }
        var isUserSellerOfThisOrderDetail = order.Sale.SellerId == int.Parse(userId);
        if(order.Sale.StatusCanBeChangedBySeller() && isUserSellerOfThisOrderDetail){
            order.Sale.Status = order.Sale.NextStatus();
            _context.SaveChanges();
            return new OrdersResponse{
                Message = "Success",
                Success = true
            };
        }
        if(order.Sale.StatusCanBeChangedByBuyer() && !isUserSellerOfThisOrderDetail){
            order.Sale.Status = order.Sale.NextStatus();
            _context.SaveChanges();
            return new OrdersResponse{
                Message = "Success",
                Success = true
            };
        }
       return new OrdersResponse{
            Message = "Error",
            Success = false
        };
    }
}