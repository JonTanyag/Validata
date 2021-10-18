using System;
using MediatR;

namespace Validata.Infrastructure.Command
{
    public class UpdateCustomerCommand : IRequest
    {
        public UpdateCustomerCommand()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
    }
}
