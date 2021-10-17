using System;
using System.Collections.Generic;

namespace Validata.Domain.Domain
{
    public class Order
    {
        public Order(DateTime orderDate, decimal totalPrice)
        {
            Id = Guid.NewGuid();
            OrderDate = orderDate;
            TotalPrice = totalPrice;
        }

        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsDeleted { get; set; }


        public virtual ICollection<Item> Items { get; set; }

        public static Order Create(DateTime orderDate, decimal totalPrice)
        {
            return new Order(orderDate, totalPrice);
        }


        public void AddItems()
        {

        }

        public void Deleted()
        {
            IsDeleted = true;
        }
    }
}
