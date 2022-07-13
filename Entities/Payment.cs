using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Payment {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PaymentId {get;set;}
    public int SaleDetailId {get;set;}
    public virtual SaleDetail Sale {get;set;}
    public string Status {get;set;}
}