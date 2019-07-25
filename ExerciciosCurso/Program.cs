using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using ExerciciosCurso.Entities;
using ExerciciosCurso.Entities.Enums;

namespace ExerciciosCurso
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine()); 

            Client client = new Client(name, email, birthDate);

            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");

            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Order order = new Order
            {
                Moment = DateTime.Now,
                OrderStatus = status,
                Client = client

            };

            Console.Write("How many items to this order? ");
            int number = int.Parse(Console.ReadLine());

            for(int i =0; i < number; i++)
            {


                Console.WriteLine($"Enter #{(i+1)} item data");
                Console.Write("Product Name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: " );         
                int qnt = int.Parse(Console.ReadLine());

                Product product = new Product(productName, productPrice);

                OrderItem item = new OrderItem(qnt, productPrice, product);

                order.Additem(item);
            }

            Console.WriteLine("ORDER SUMMARY:");

            Console.WriteLine(order);
        }
    }
}
