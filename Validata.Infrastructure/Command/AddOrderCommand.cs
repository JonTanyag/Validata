using System;
using System.Collections.Generic;
using MediatR;
using Validata.Domain.Domain;

namespace Validata.Infrastructure.Command
{
    public class AddOrderCommand : IRequest
    {
        public AddOrderCommand()
        {
        }

        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public List<Item> Items { get; set; }
    }
}
