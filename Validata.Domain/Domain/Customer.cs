using System;
using System.Collections.Generic;

namespace Validata.Domain.Domain
{
    public partial class Customer
    {
        public Customer(string firstName, string lastName, string address, string postalCode)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PostalCode = postalCode;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Order> Orders { get; private set; }

        public static Customer Create(string firstName, string lastName, string address, string postalCode)
        {
            return new Customer(firstName, lastName, address, postalCode);
        }

        public void ChangeDetails(string firstName, string lastName, string address, string postalCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PostalCode = postalCode;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
