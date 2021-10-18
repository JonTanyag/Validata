using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Validata.Domain.Domain;
using Validata.Domain.Repositories;
using Validata.Infrastructure.Command;

namespace Validata.API.Application.CommandHandlers
{
    public class OrderCommandHandler : IRequestHandler<AddOrderCommand>, IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderCommandHandler(IOrderRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddOrderCommand command, CancellationToken cancellationToken)
        {
            var orderEntity = new Order();

            var order = orderEntity.Create(command.OrderDate, command.TotalPrice);

            foreach (var item in command.Items)
            {
                order.AddItems(item);
            }
            
            _ = _repository.Add(order);
            _ = _unitOfWork.CompleteAsync();

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            var order = new Order();

            foreach (var item in command.Items)
            {
                order.RemoveItem(item);
            }

            foreach (var item in command.Items)
            {
                order.AddItems(item);
            }

            await _repository.Upsert(order);
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
