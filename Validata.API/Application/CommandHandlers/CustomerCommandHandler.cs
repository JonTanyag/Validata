using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Validata.Domain.Domain;
using Validata.Domain.Repositories;
using Validata.Infrastructure.Command;

namespace Validata.API.Application.CommandHandlers
{
    public class CustomerCommandHandler : IRequestHandler<AddCustomerCommand>, IRequestHandler<UpdateCustomerCommand>
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
            //var customerManager = _customerManagerRepository.FindFirstAsync(null);
            var customerEntity = new Customer();


            var customer = customerEntity.Create(command.FirstName, command.LastName, command.Address, command.PostalCode); //customerManager?.Result?.CreateCustomer(command.FirstName, command.LastName, command.Address, command.PostalCode);

            await _repository.Add(customer);
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = new Customer();

            customer.ChangeDetails(command.FirstName, command.LastName, command.Address, command.PostalCode);

            await _repository.Upsert(customer);

            return Unit.Value;
        }
    }
}
