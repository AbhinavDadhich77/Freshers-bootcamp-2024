
using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        Console.WriteLine ("Hello World");
        int EmployeeId = 0;
        string Name = "";
        double salary = 0.0;
        
        Console.WriteLine("Enter Employee ID");
        EmployeeId = System.Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Enter the Name");
        Name = Console.ReadLine();
        
        Console.WriteLine("Enter the Salary");
        salary = Convert.ToDouble(Console.ReadLine());
        
        
        
        
        Console.ReadLine();
    }
}
