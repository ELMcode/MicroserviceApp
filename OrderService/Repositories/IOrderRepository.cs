using OrderService.Models;

namespace OrderService.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(string id);
        Task CreateAsync(Order order);
        Task UpdateAsync(string id, Order order);
        Task RemoveAsync(string id);
    }
}