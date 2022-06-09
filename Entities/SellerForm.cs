using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Entities;

public class SellerForm
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   public int IdSellerForm { get; set; }
    public int IdAccount { get; set; }
    public Account Account { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string DNI { get; set; }
    public string DNIImage_Front { get; set; }
    public string DNIImage_Back {get;set;}
    public string Phone { get; set; }
    public List<BankAccount> BankAccount { get; set; }
    public bool AcceptAllTerms { get; set; }
    public bool AcceptDevolutionConditions { get; set; }
    public bool isApproved { get; set; }

    internal SellerFormDto toDTO()
    {
        return new SellerFormDto
        {
            UserId = this.IdAccount.ToString(),
            City = this.City,
            Dni = this.DNI,
            Address = this.Address,
            Phone = this.Phone,
            DniFront = this.DNIImage_Front,
            DniBack = this.DNIImage_Back,
            AcceptTerms = this.AcceptAllTerms,
            AcceptDevolutionterms = this.AcceptDevolutionConditions,
            isApproved = this.isApproved
        };
    }
}