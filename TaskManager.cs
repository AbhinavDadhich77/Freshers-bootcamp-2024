using System;

public class DynamicArray<T>
{
    private T[] array;
    private int capacity;
    private int count;

    public DynamicArray(int initialCapacity)
    {
        if (initialCapacity <= 0)
        {
            throw new ArgumentException("Initial capacity must be greater than zero.");
        }

        this.capacity = initialCapacity;
        this.array = new T[capacity];
        this.count = 0;
    }

    public int Count
    {
        get { return count; }
    }

    public void Add(int index, T item)
    {
        if (index < 0 || index > count)
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }

        
        if (count == array.Length)
        {
            ResizeArray();
        }

        
        for (int i = count; i > index; i--)
        {
            array[i] = array[i - 1];
        }

        
        array[index] = item;

        
        count++;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            return array[index];
        }
    }

    private void ResizeArray()
    {
        int newCapacity = array.Length + 10; // Increase by a fixed amount
        T[] newArray = new T[newCapacity];
        Array.Copy(array, newArray, count);
        array = newArray;
    }
}

public class Program
{
    static void Main()
    {
        DynamicArray<int> numbers = new DynamicArray<int>(2);
        numbers.Add(0, 100);
        numbers.Add(1, 200);
        numbers.Add(2, 300);
        numbers.Add(3, 400);
        int value = numbers[2];
        Console.WriteLine($"Total Number Of Items in Array: {numbers.Count}, Value: {value} at index: 2");

        DynamicArray<string> stringItems = new DynamicArray<string>(2);
        stringItems.Add(0, "100");
        stringItems.Add(1, "200");
        stringItems.Add(2, "300");
        stringItems.Add(3, "400");
        string itemValue = stringItems[3];
        Console.WriteLine($"Total Number Of Items in Array: {stringItems.Count}, Value: {itemValue} at index: 3");
    }
}
