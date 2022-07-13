namespace WebApi.Helpers;

using System;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

public class DataContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Size> Size {get;set;}
    public DbSet<Brand> Brand { get; set; }
    public DbSet<Currency> Currency {get;set;}
    public DbSet<BankAccount> BankAccount {get;set;}
    public DbSet<SellerForm> SellerForm {get;set;}
    public DbSet<Sale> Sale {get;set;}
    public DbSet<SaleDetail> SaleDetail {get;set;}
    public DbSet<Payment> Payment {get;set;}
    public DbSet<Cards> Cards {get;set;}
    public DbSet<CustomerPayment> CustomerPayment {get;set;}

    private readonly IConfiguration Configuration;
    

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {  
        var connectionString = Configuration.GetConnectionString("WebApiDatabase");
        options.UseMySql(connectionString, 
        ServerVersion.AutoDetect(connectionString)); 
        options.UseLazyLoadingProxies();       
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SellerForm>().HasOne(x => x.Account).WithOne(x => x.SaleForm).HasForeignKey<SellerForm>(x => x.IdAccount);
        modelBuilder.Entity<SaleDetail>().HasOne(x => x.Sale).WithMany(x => x.SaleDetails).HasForeignKey(x => x.SaleId);
        modelBuilder.Entity<SaleDetail>().HasOne(x => x.Product).WithOne(x => x.Sale).HasForeignKey<SaleDetail>(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Product>().HasOne(x=>x.Sale).WithOne(x=>x.Product).HasForeignKey<SaleDetail>(x=>x.ProductId);
    }
}