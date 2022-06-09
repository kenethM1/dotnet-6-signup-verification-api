using WebApi.Entities;

public class Sale {
    public int SaleId { get; set; }
    public int CustomerId { get; set; }
    public Account Customer { get; set; }
    public CustomerPayment CustomerPayment { get; set; }
    public List<SaleDetail> SaleDetails { get; set; }
    public string ShippingAddress { get; set; }
    public string BillingAddress { get; set; }
}