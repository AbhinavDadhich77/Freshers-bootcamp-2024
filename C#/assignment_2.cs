using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Product
{
    public int ProdId { get; set; }
    public string Name { get; set; }
    public DateTime MfgDate { get; set; }
    public int Warranty { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    public int Gst { get; set; }
    public int Discount { get; set; }

    public void Display()
    {
        double taxPrice = Price * Gst / 100.0;
        double totalDiscountPrice = (Price - (Price * Discount / 100.0)) * Stock;

        Console.WriteLine($"Product ID: {ProdId}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Manufacturing Date: {MfgDate}");
        Console.WriteLine($"Warranty: {Warranty} months");
        Console.WriteLine($"Price: {Price:C}");
        Console.WriteLine($"Stock: {Stock}");
        Console.WriteLine($"GST: {Gst}%");
        Console.WriteLine($"Discount: {Discount}%");
        Console.WriteLine($"Tax Price: {taxPrice:C}");
        Console.WriteLine($"Total Discount Price: {totalDiscountPrice:C}");
        Console.WriteLine("------------------------------");
    }
}

class Program
{
    static void Main()
    {
        Product[] products = new Product[100]; // Assuming a maximum of 100 products

        int productCount = 0;

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Search");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter the number of products to add: ");
                    int numberOfProducts = int.Parse(Console.ReadLine());

                    for (int i = 0; i < numberOfProducts; i++)
                    {
                        Product product = new Product();
                        Console.Write("Enter Product ID: ");
                        product.ProdId = int.Parse(Console.ReadLine());

                        Console.Write("Enter Name: ");
                        product.Name = Console.ReadLine();

                        Console.Write("Enter Manufacturing Date (MM/DD/YYYY): ");
                        product.MfgDate = DateTime.Parse(Console.ReadLine());

                        Console.Write("Enter Warranty (months): ");
                        product.Warranty = int.Parse(Console.ReadLine());

                        Console.Write("Enter Price: ");
                        product.Price = double.Parse(Console.ReadLine());

                        Console.Write("Enter Stock: ");
                        product.Stock = int.Parse(Console.ReadLine());

                        Console.Write("Enter GST (5, 12, 18, 28): ");
                        product.Gst = int.Parse(Console.ReadLine());

                        if (product.Gst != 5 && product.Gst != 12 && product.Gst != 18 && product.Gst != 28)
                        {
                            Console.WriteLine("Invalid GST value. Setting to default (5%).");
                            product.Gst = 5;
                        }

                        Console.Write("Enter Discount (1, 2, 30): ");
                        product.Discount = int.Parse(Console.ReadLine());

                        if (product.Discount != 1 && product.Discount != 2 && product.Discount != 30)
                        {
                            Console.WriteLine("Invalid Discount value. Setting to default (1%).");
                            product.Discount = 1;
                        }

                        products[productCount++] = product;
                    }
                    break;

                case 2:
                    if (productCount > 0)
                    {
                        Console.WriteLine("All Products:");
                        foreach (var product in products)
                        {
                            if (product != null)
                                product.Display();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No products added yet.");
                    }
                    break;

                case 3:
                    Console.Write("Enter Product ID to search: ");
                    int searchId = int.Parse(Console.ReadLine());

                    bool found = false;
                    foreach (var product in products)
                    {
                        if (product != null && product.ProdId == searchId)
                        {
                            product.Display();
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine($"Product with ID {searchId} not found.");
                    }
                    break;

                case 4:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}

