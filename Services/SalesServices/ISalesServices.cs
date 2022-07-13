public interface ISalesService
{
    OrdersResponse GetMyOrders(string userId);
    OrdersResponse UpdateOrderStatus(string userId, string orderId);
    OrdersResponse GetUnpaidSales(int userId);
}