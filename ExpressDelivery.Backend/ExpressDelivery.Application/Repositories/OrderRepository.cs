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

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _dbContext.Order.ToListAsync();
        }

        public async Task<Order> Get(Guid id)
        {
            return await _dbContext.Order.SingleOrDefaultAsync(order => order.Id == id) ?? throw new NotFoundException("Order not found", id);
        }

        public async Task<IEnumerable<Order>> GetQuery(string queryText)
        {
            queryText = queryText.ToLower();
            var result = await _dbContext.Order
                .Where(order =>
                    order.Name.ToLower().Contains(queryText) ||
                    order.ReceiptAddress.ToLower().Contains(queryText) ||
                    order.DeliveryAddress.ToLower().Contains(queryText) ||
                    order.Description.ToLower().Contains(queryText)
                ).ToListAsync();

            return result;
        }

        public async Task<Guid> Create(Order order)
        {
            await _dbContext.Order.AddAsync(order);

            return order.Id; // TODO: проверить, и подумать, надо ли вообще что-то возвращать
        }

        public async Task Update(Order order)
        {
            var orderToUpdate = await _dbContext.Order.FindAsync(order.Id);
            if (orderToUpdate == null)
                return;

            orderToUpdate.Name = order.Name;
            orderToUpdate.Description = order.Description;
            orderToUpdate.ReceiptAddress = order.ReceiptAddress;
            orderToUpdate.DeliveryAddress = order.DeliveryAddress;
            orderToUpdate.ReceiptTime = order.ReceiptTime;
            orderToUpdate.DeliveryTime = order.DeliveryTime;
        }

        public async Task UpdateStatus(Guid id, int orderStatusId)
        {
            var orderToUpdateStatus = await _dbContext.Order.SingleOrDefaultAsync(order => order.Id == id);
            if (orderToUpdateStatus == null)
                return;

            orderToUpdateStatus.OrderStatusId = orderStatusId;
        }

        public async Task Delete(Guid id, int orderStatusDeleteId)
        {
            var orderToDelete = await _dbContext.Order.SingleOrDefaultAsync(order => order.Id == id);
            if (orderToDelete == null)
                return;

            orderToDelete.OrderStatusId = orderStatusDeleteId;
        }

        public async Task AssignmentExecutor(Guid orderId, Guid executorId)
        {
            var orderToAssignment = await _dbContext.Order.SingleOrDefaultAsync(order => order.Id == orderId);
            if (orderToAssignment == null)
                return;

            orderToAssignment.ExecutorId = executorId;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
