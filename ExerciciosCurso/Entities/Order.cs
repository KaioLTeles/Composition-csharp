using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using ExerciciosCurso.Entities.Enums;
using ExerciciosCurso.Entities;
namespace ExerciciosCurso.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus orderStatus, Client client)
        {
            Moment = moment;
            OrderStatus = orderStatus;
            Client = client;
        }

        public void Additem(OrderItem item)
        {
            Items.Add(item);
        }

        public void Removeitem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double result = 0.0;

            foreach(OrderItem item in Items)
            {
                result += item.SubTotal();
            }

            return result;

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order moment: " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order status: " + OrderStatus);
            sb.AppendLine("Client: " + Client);
            sb.AppendLine("Order Items");
            foreach(OrderItem item in Items)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
