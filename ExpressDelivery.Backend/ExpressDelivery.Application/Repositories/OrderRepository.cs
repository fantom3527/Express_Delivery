using ExpressDelivery.Application.Common.Exception;
using ExpressDelivery.Application.Interfaces;
using ExpressDelivery.Application.Repositories.Interfaces;
using ExpressDelivery.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExpressDelivery.Application.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IExpressDeliveryDbContext _dbContext;

        public OrderRepository(IExpressDeliveryDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<IEnumerable<Order>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Order.ToListAsync(cancellationToken);
        }

        public async Task<Order> Get(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Order.FindAsync(new object[] { id }, cancellationToken) ?? throw new NotFoundException("Order not found", id);
        }

        public async Task<IEnumerable<Order>> GetQuery(string queryText, CancellationToken cancellationToken = default)
        {
            queryText = queryText.ToLower();
            var result = await _dbContext.Order
                .Where(order =>
                    order.Name.ToLower().Contains(queryText) ||
                    order.ReceiptAddress.ToLower().Contains(queryText) ||
                    order.DeliveryAddress.ToLower().Contains(queryText) ||
                    order.Description.ToLower().Contains(queryText)
                ).ToListAsync(cancellationToken);

            return result;
        }

        public async Task<Guid> Create(Order order, CancellationToken cancellationToken = default)
        {
            await _dbContext.Order.AddAsync(order, cancellationToken);

            return order.Id;
        }

        public async Task Update(Order order, CancellationToken cancellationToken = default)
        {
            var orderToUpdate = await _dbContext.Order.FindAsync(new object[] { order.Id }, cancellationToken);
            if (orderToUpdate == null)
                return;

            orderToUpdate.Name = order.Name;
            orderToUpdate.Description = order.Description;
            orderToUpdate.ReceiptAddress = order.ReceiptAddress;
            orderToUpdate.DeliveryAddress = order.DeliveryAddress;
            orderToUpdate.ReceiptTime = order.ReceiptTime;
            orderToUpdate.DeliveryTime = order.DeliveryTime;
        }

        public async Task UpdateStatus(Guid id, int orderStatusId, CancellationToken cancellationToken = default)
        {
            var orderToUpdateStatus = await _dbContext.Order.FindAsync(new object[] { id }, cancellationToken);
            if (orderToUpdateStatus == null)
                return;

            orderToUpdateStatus.OrderStatusId = orderStatusId;
        }

        public async Task Delete(Guid id, int orderStatusDeleteId, CancellationToken cancellationToken = default)
        {
            var orderToDelete = await _dbContext.Order.FindAsync(new object[] { id }, cancellationToken);
            if (orderToDelete == null)
                return;

            orderToDelete.OrderStatusId = orderStatusDeleteId;
        }

        public async Task AddExecutor(Guid id, Guid executorId, CancellationToken cancellationToken = default)
        {
            var addExecutorToOrder = await _dbContext.Order.FindAsync(new object[] { id }, cancellationToken);
            if (addExecutorToOrder == null)
                return;

            addExecutorToOrder.ExecutorId = executorId;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
