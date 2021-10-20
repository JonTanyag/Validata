using System;
using System.Collections.Generic;
using System.Linq;

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

        public Order()
        {
        }

        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsDeleted { get; set; }


        //public virtual ICollection<Item> Items { get; set; }

        public Order Create(DateTime orderDate, decimal totalPrice)
        {
            return new Order(orderDate, totalPrice);
        }


        public void AddItems(Item item)
        {
           // Items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            //var itemToDelete = Items.FirstOrDefault(i => i.Id == item.Id);
            //if (itemToDelete == null)
            //    throw new Exception("Item to delete does not exist.");

            //itemToDelete.Delete(itemToDelete.Id);
        }

        public void Deleted()
        {
            IsDeleted = true;
        }
    }
}
