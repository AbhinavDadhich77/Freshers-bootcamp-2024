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
        Dictionary<int, Product> products = new Dictionary<int, Product>();

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Search");
            Console.WriteLine("4. Remove");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    do
                    {
                        Product product = new Product();
                        Console.Write("Enter Product ID: ");
                        int productId = int.Parse(Console.ReadLine());

                        if (products.ContainsKey(productId))
                        {
                            Console.WriteLine($"Product with ID {productId} already exists. Please enter a different ID.");
                            continue;
                        }

                        product.ProdId = productId;

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

                        products.Add(productId, product);

                        Console.Write("Do you want to add another product? (yes/no): ");
                    } while (Console.ReadLine().Equals("yes", StringComparison.OrdinalIgnoreCase));
                    break;

                case 2:
                    if (products.Count > 0)
                    {
                        Console.WriteLine("All Products:");
                        foreach (var product in products.Values)
                        {
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

                    if (products.TryGetValue(searchId, out Product foundProduct))
                    {
                        foundProduct.Display();
                    }
                    else
                    {
                        Console.WriteLine($"Product with ID {searchId} not found.");
                    }
                    break;

                case 4:
                    Console.Write("Enter Product ID to remove: ");
                    int removeId = int.Parse(Console.ReadLine());

                    if (products.ContainsKey(removeId))
                    {
                        products.Remove(removeId);
                        Console.WriteLine($"Product with ID {removeId} removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"Product with ID {removeId} not found.");
                    }
                    break;

                case 5:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
