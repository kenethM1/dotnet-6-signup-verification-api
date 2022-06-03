using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Entities;

public class SaleDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SaleId { get; set; }
    public int SellerId { get; set; }
    public Account Seller { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public string Status { get; set; }
}