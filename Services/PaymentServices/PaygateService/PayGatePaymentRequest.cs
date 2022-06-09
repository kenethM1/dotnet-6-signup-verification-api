public class PayGatePaymentRequest {
    public double Amount { get; set; }
    public string ValidThru { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Description { get; set; }
    public string SafeIdentifier { get; set; }
    public string CardId { get; set; }
    public string CustomerId { get; set; }
    public string CVV { get; set; }
}