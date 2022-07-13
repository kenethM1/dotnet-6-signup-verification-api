using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Entities;

public class Cards
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CardId { get; set; }
    public string Name { get; set; }
    public string CardNetwork { get; set; }
    public string CardNumberHash { get; set; }
    public string CVVHash { get; set; }
    public string ExpirationDate { get; set; }
    public int AccountId { get; set; }
    public virtual Account Account { get; set; }
    public bool IsDefault { get; set; }
    public bool IsActive { get; set; }
}
