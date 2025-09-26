using System;

using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");

        Customer customer1 = new Customer("Peter Justin", address1);

        Order order1 = new Order(customer1);

        Product product1 = new Product("Laptop", "P-101", 1200.50, 1);
        Product product2 = new Product("Mouse", "P-102", 25.00, 2);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Console.WriteLine("--- Order 1 ---");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Order Cost: ${order1.GetTotalCost():F2}\n");

        Address address2 = new Address("456 International Blvd", "Global City", "Ontario", "Canada");

        Customer customer2 = new Customer("Mark Johnson", address2);

        Order order2 = new Order(customer2);

        Product product3 = new Product("Wallet", "P-103", 75.00, 1);
        Product product4 = new Product("Laptop", "P-104", 15.00, 5);
        Product product5 = new Product("Webcam", "P-105", 50.00, 1);
        order2.AddProduct(product3);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        Console.WriteLine("--- Order 2 ---");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Order Cost: ${order2.GetTotalCost():F2}\n");
    }
}