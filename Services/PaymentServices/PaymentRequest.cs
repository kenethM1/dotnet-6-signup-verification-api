public class PaymentRequest 
{
    public string CardNumber { get; set; }
    public string CardHolderName { get; set; }
    public string ExpirationDate { get; set; }
    public string CVV { get; set; }
    public string ShippingAddress { get; set; }
    
    public string UserId { get; set; }
    public List<string> ProductsId { get; set; }
}