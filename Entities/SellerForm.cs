using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class SellerForm
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   public int IdSellerForm { get; set; }
    public int IdAccount { get; set; }
    public string Address { get; set; }
    public string DNI { get; set; }
    public string DNIImage_Front { get; set; }
    public string DNIImage_Back {get;set;}
    public string Phone { get; set; }
    public List<BankAccount> BankAccount { get; set; }
    public bool AcceptAllTerms { get; set; }
    public bool AcceptDevolutionConditions { get; set; }
}