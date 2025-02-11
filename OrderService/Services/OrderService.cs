using OrderService.Models;
using OrderService.Repositories;

namespace OrderService.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository orderRepository)
        {
            _repository = orderRepository;
        }

        public async Task<List<Order>> GetAllOrdersAsync() =>
            await _repository.GetAllAsync();

        public async Task<Order?> GetOrderByIdAsync(string id) =>
            await _repository.GetByIdAsync(id);

        public async Task AddOrderAsync(Order order)
        {
            await _repository.CreateAsync(order);
        }

        public async Task UpdateOrderAsync(Order order) =>
            await _repository.UpdateAsync(order.Id, order);

        public async Task DeleteOrderAsync(string id) =>
            await _repository.RemoveAsync(id);
    }
}