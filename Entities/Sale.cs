using WebApi.Entities;

public class Sale {
    public int SaleId { get; set; }
    public int CustomerId { get; set; }
    public Account Customer { get; set; }
    public int CardId { get; set; }
    public Cards Card { get; set; }
    public string ShippingAddress { get; set; }
    public string BillingAddress { get; set; }
    public string CurrencyId { get; set; }
}