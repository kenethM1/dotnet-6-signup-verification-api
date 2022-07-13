using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Entities;

public class CustomerPayment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CustomerPaymentId { get; set; }
    public int SaleId { get; set; }
    public virtual Sale Sale { get; set; }
    public string CustomerId { get; set; }
    public virtual Account Customer { get; set; }
    public string Status { get; set; }
    public double Amount { get; set; }
    public string PayGateTransactionId { get; set; }
    
}