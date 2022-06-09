public class OrdersResponse : ResponseBase{
    public List<ProductsDTO> MyPurchases { get; set; }
    public List<ProductsDTO> MySales { get; set; }

}