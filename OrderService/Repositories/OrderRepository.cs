using MongoDB.Driver;
using OrderService.Data;
using OrderService.Models;

namespace OrderService.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<Order> _orders;

        public OrderRepository(OrderContext context)
        {
            _orders = context.Orders;
        }

        public async Task<List<Order>> GetAllAsync() =>
            await _orders.Find(_ => true).ToListAsync();

        public async Task<Order?> GetByIdAsync(string id) =>
            await _orders.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Order order) =>
            await _orders.InsertOneAsync(order);

        public async Task UpdateAsync(string id, Order order) =>
            await _orders.ReplaceOneAsync(x => x.Id == id, order);

        public async Task RemoveAsync(string id) =>
            await _orders.DeleteOneAsync(x => x.Id == id);
    }
}