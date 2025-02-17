namespace WebApi.Entities;

public class Account
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string ProfilePicture { get; set; }
    public string PasswordHash { get; set; }
    public bool AcceptTerms { get; set; }
    public virtual Role Role { get; set; }
    public virtual List<Product> Products { get; set; }
    public virtual List<Cards> Cards { get; set; }
    public virtual List<CustomerPayment> CustomerPayment { get; set; }
    public virtual SellerForm SaleForm { get; set; }
    public string VerificationToken { get; set; }
    public string VerificationCode { get; set; }
    public DateTime? Verified { get; set; }
    public bool IsVerified => Verified.HasValue || PasswordReset.HasValue;
    public string ResetToken { get; set; }
    public DateTime? ResetTokenExpires { get; set; }
    public DateTime? PasswordReset { get; set; }

    internal AccountDTO FromEntity()
    {
        return new AccountDTO{
            Id = this.Id,
            ProfilePicture = this.ProfilePicture,
            FirstName = this.FirstName,
            LastName = this.LastName
        };
    }

    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    public List<RefreshToken> RefreshTokens { get; set; }

    public bool OwnsToken(string token) 
    {
        return this.RefreshTokens?.Find(x => x.Token == token) != null;
    }
}