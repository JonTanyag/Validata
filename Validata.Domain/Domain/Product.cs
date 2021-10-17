using System;
namespace Validata.Domain.Domain
{
    public class Product
    {
        public Product(string name, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public static Product Create(string name, decimal price)
        {
            return new Product(name, price);
        }
    }
}
