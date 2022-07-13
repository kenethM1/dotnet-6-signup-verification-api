using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Entities;

public class SaleDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SaleId { get; set; }
    public int SellerId { get; set; }
    public virtual Sale Sale { get; set; }
    public virtual Account Seller { get; set; }
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }
    public string Status { get; set; }

    internal bool StatusCanBeChangedBySeller()
    {
        return Status == Statuses.Pending;
    }

    internal string NextStatus()
    {
        if (Status == Statuses.Pending)
            return Statuses.Delivering;
        if (Status == Statuses.Delivering)
            return Statuses.Delivered;
        return Statuses.Error;
    }

    internal bool StatusCanBeChangedByBuyer()
    {
        return Status == Statuses.Delivering;
    }
}