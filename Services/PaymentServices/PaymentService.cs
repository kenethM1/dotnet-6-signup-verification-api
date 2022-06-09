using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;
using WebApi.Entities;

public class PaymentService : IPaymentService
{
    private readonly DataContext _context;
    private readonly IPayGate _payGate;
    private readonly IProductsService _productsService;
    public PaymentService(DataContext context, IPayGate payGate, IProductsService productsService)
    {
        _context = context;
        _payGate = payGate;
        _productsService = productsService;
    }
    public PaymentResponse Pay(PaymentRequest request)
    {
        var error = ValidateRequest(request);
        if (!string.IsNullOrEmpty(error))
        {
            return new PaymentResponse
            {
                Message = error
            };
        }
        var PaymentRequest = new PayGatePaymentRequest
        {
            Amount = GetAmount(request.ProductsId),
            ValidThru = request.ExpirationDate,
            SafeIdentifier = request.CardNumber,
            CVV = request.CVV,
            FirstName = request.CardHolderName,
            Description = "Payment for products",
        };
        var payGateResponse = _payGate.Pay(PaymentRequest);

        var message = CreateOrder(request, payGateResponse);


        _context.SaveChanges();
       
        return new PaymentResponse
        {
            Success= true,
            Message = payGateResponse.Message
        };
    }

    private string CreateOrder(PaymentRequest request, PayGateResponse payGateResponse)
    {
        if (payGateResponse.Status != "APPROVED")
        {
            return payGateResponse.Message;
        }
        var order = new Sale
        {
            ShippingAddress = request.ShippingAddress,
            CustomerId = int.Parse(request.UserId),
            BillingAddress = request.ShippingAddress,
            SaleDetails = GetSaleDetails(request.ProductsId),
            CustomerPayment = new CustomerPayment
        {
            Amount = GetAmount(request.ProductsId),
            CustomerId = request.UserId,
            PayGateTransactionId = payGateResponse._Id,
            Status = "PENDING"       
        }};       
        _context.Sale.Add(order);
        return string.Empty;
    }

    private List<SaleDetail> GetSaleDetails(List<string> productsId)
    {
        var saleDetails = new List<SaleDetail>();
        foreach (var productId in productsId)
        {
            var product = _productsService.GetProduct(productId);
             _productsService.MakeProductUnavailable(product);
            saleDetails.Add(new SaleDetail
            {
                ProductId = product.Id,
                SellerId = product.AccountId,
                Status = Statuses.Pending,
            });
        }
        return saleDetails;
    }

    private double GetAmount(List<string> productsId)
    {
        var products = _context.Products.Where(x => productsId.Contains(x.Id.ToString())).ToList();
        var amount = products.Sum(x => x.Price);
        return ((double)amount);
    }

    private string ValidateRequest(PaymentRequest request)
    {
        string error =string.Empty;
        var properties = request.GetType().GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(request);
            if (value == null)
            {
                error = $"{property.Name} is required";
                break;
            }
            if(property.Name == "ProductsId")
            {
                var productsId = value as List<string>;
                var products = _context.Products.Where(x =>productsId.Contains(x.Id.ToString())).ToList();
                var isAnyProductSelled = products.Any(x => x.IsSelled == true);
                if(products.Count != productsId.Count)
                {
                    error = "Invalid products";
                    break;
                }
                if(isAnyProductSelled)
                {
                    error = "One or more products are already sold";
                    break;
                }
            }
        }
        return error;
    }
}