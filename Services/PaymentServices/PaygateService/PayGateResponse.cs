public class PayGateResponse : ResponseBase
{
public string Status { get; set; }
public string Tax { get; set; }
public string OriginService { get; set; }
public string LiquidationStatus {get;set;}
public string _Id { get; set; }
public double Amount { get; set; }
public string ValidThru { get; set; }
public string FirstName { get; set; }
public string LastName { get; set; }
public string Description { get; set; }
public string SafeIdentifier { get; set; }
public DateTime CreatedAt { get; set; }

public double Subtotal { get; set; }
public string PaymentType { get; set; }
public string TransactionId { get; set; }

}