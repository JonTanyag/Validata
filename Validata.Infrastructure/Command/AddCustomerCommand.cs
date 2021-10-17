using System;
using MediatR;

namespace Validata.Infrastructure.Command
{
    public class AddCustomerCommand : IRequest
    {
        public AddCustomerCommand()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
    }
}
