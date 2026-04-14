using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Customer> customers = new List<Customer>();
        Customer customer = new Customer { Name = "" }; 
        string mName = "";

        while (string.IsNullOrWhiteSpace(mName))
        {
            Console.Write("Enter Customer Name: ");
            mName = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(mName))
            {
                Console.WriteLine("Name cannot be empty. Please enter a valid name.");
            }
        }

        customer.Name = mName;

        Console.Write("Enter number of coffee bags: ");
        customer.CoffeeBags = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Is reseller (true/false): ");
        customer.IsReseller = bool.Parse(Console.ReadLine() ?? "false");

        customers.Add(customer);

        double totalCost = CalculateCost(customer.CoffeeBags);

        BillingViewModel vm = new BillingViewModel();
        double discount = vm.CalculateDiscount(totalCost, customer.IsReseller);
        double finalCost = totalCost - discount;

        Console.WriteLine($"Total cost: {totalCost}");
        Console.WriteLine($"Discount: {discount}");
        Console.WriteLine($"Final cost: {finalCost}");

    }

    static double CalculateCost(int numCoffeeBags)
    {
        if (numCoffeeBags < 6)
            return numCoffeeBags * 36;
        else if (numCoffeeBags < 16)
            return numCoffeeBags * 34.5;
        else
            return numCoffeeBags * 32.7;
    }
}