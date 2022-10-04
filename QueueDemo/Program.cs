using System;
using System.Collections.Generic;
using System.Transactions;

namespace QueueDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<Order> ordersQueue = new Queue<Order>();

            foreach(Order o in RecieveOrdersFromBranch1())
            {
                // add each order to the queue
                ordersQueue.Enqueue(o);
            }

            foreach (Order o in RecieveOrdersFromBranch2())
            {
                // add each order to the queue
                ordersQueue.Enqueue(o);
            }

            //as long as the order queue is not empty
            while(ordersQueue.Count > 0)
            {
                //remove the order at the front of the queue
                //and store it in a variable called current Order
                Order currentOrder  = ordersQueue.Dequeue();
                //Process the order
                currentOrder.ProcessOrder();
            }


        }
        // this method will create an array of orders and return it
        static Order[] RecieveOrdersFromBranch1()
        {
            Order[] orders = new Order[]
            {
                new Order(1,5),
                new Order(2,4),
                new Order(6,10)
            };
            return orders;
        }

        static Order[] RecieveOrdersFromBranch2()
        {
            Order[] orders = new Order[]
            {
                new Order(2,3),
                new Order(3,7),
                new Order(9,10)
            };
            return orders;
        }
    }

    class Order
    {

        public int orderId { get; set; }
        public int OrderQuantity { get; set; }

        public Order(int Id, int orderQuantity)
        {
            this.orderId = Id;
            this.OrderQuantity = orderQuantity;
        }

        public void ProcessOrder()
        {
            Console.WriteLine($"Order {orderId} processed!");
        }
    }
}
