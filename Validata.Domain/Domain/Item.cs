using System;
namespace Validata.Domain.Domain
{
    public class Item
    {
        public Item(Product product, int quantity)
        {
            Id = Guid.NewGuid();
            Products = product;
            Quantity = quantity;
        }

        public Guid Id { get; set; }
        public Product Products { get; set; }
        public int Quantity { get; set; }
    }
}
