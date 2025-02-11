using MongoDB.Driver;
using OrderService.Models;

namespace OrderService.Data
{
    public class OrderContext
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Order> _orders;

        public OrderContext(OrderDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
            _orders = _database.GetCollection<Order>(settings.OrdersCollectionName);
        }

        public IMongoCollection<Order> Orders => _orders;
    }
}