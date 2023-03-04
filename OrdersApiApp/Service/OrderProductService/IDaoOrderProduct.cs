using OrdersApiApp.Model.Entity;

namespace OrdersApiApp.Service.OrderProductService
{
    public interface IDaoOrderProduct
    {
        Task<List<OrderProduct>> GetAllOrderProducts();
        Task<OrderProduct> GetOrderProductById(int id);
        Task<OrderProduct> AddOrderProduct(OrderProduct orderproduct);
        Task<OrderProduct> UpdateOrderProduct(OrderProduct orderproduct);
        Task<bool> DeleteOrderProduct(int id);
    }
}
