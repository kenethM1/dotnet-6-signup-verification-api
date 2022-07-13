using WebApi.Entities;

public class Sale {
    public int SaleId { get; set; }
    public int CustomerId { get; set; }
    public virtual Account Customer { get; set; }
    public virtual CustomerPayment CustomerPayment { get; set; }
    public virtual List<SaleDetail> SaleDetails { get; set; }
    public string ShippingAddress { get; set; }
    public string BillingAddress { get; set; }
}