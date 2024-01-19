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
    }
}

class Program
{
    static void Main()
    {
        Product product = null;

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    product = new Product();
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

                    break;

                case 2:
                    if (product != null)
                        product.Display();
                    else
                        Console.WriteLine("No product added yet.");
                    break;

                case 3:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
