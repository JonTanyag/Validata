using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Validata.Domain.Repositories;
using Validata.Infrastructure.Command;

namespace Validata.API.Application.CommandHandlers
{
    public class CustomerCommandHandler : IRequestHandler<AddCustomerCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly ICustomerManagerRepository _customerManagerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerCommandHandler(ICustomerRepository repository, ICustomerManagerRepository customerManagerRepository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _customerManagerRepository = customerManagerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddCustomerCommand command, CancellationToken cancellationToken)
        {
            var customerManager = _customerManagerRepository.FindFirstAsync(null);

            var customer = customerManager.Result.CreateCustomer(command.FirstName, command.LastName, command.Address, command.PostalCode);

            _ = _repository.Add(customer);
            _ = _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
