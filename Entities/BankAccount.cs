using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Entities;

public class BankAccount{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BankAccountId { get; set; }
    public int SellerId { get; set; }
    public virtual Account Account { get; set; }
    public virtual SellerForm SellerForm { get; set; }
    public string AccountNumber { get; set; }
    public string AccountHolder { get; set; }
    public string BankName { get; set; }
    public string AcountType { get; set; }
    public string Currency { get; set; }
    
}