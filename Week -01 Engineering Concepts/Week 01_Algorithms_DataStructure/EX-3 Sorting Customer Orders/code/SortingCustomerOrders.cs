using System;

public class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public double TotalPrice { get; set; }

    public Order(int id, string name, double price)
    {
        OrderId = id;
        CustomerName = name;
        TotalPrice = price;
    }

    public void Display()
    {
        Console.WriteLine($"OrderID: {OrderId}, Customer: {CustomerName}, Total: ₹{TotalPrice}");
    }
}

public class OrderSorting
{
    public static void BubbleSort(Order[] orders)
    {
        int n = orders.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (orders[j].TotalPrice > orders[j + 1].TotalPrice)
                {
                    var temp = orders[j];
                    orders[j] = orders[j + 1];
                    orders[j + 1] = temp;
                }
            }
        }
    }

    public static void QuickSort(Order[] orders, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(orders, low, high);
            QuickSort(orders, low, pivotIndex - 1);
            QuickSort(orders, pivotIndex + 1, high);
        }
    }

    private static int Partition(Order[] orders, int low, int high)
    {
        double pivot = orders[high].TotalPrice;
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (orders[j].TotalPrice <= pivot)
            {
                i++;
                var temp = orders[i];
                orders[i] = orders[j];
                orders[j] = temp;
            }
        }

        var t = orders[i + 1];
        orders[i + 1] = orders[high];
        orders[high] = t;

        return i + 1;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Order[] orders = new Order[]
        {
            new Order(1, "Alice", 4500),
            new Order(2, "Bob", 1200),
            new Order(3, "Charlie", 8200),
            new Order(4, "Diana", 3000),
        };

        Console.WriteLine("Original Orders:");
        foreach (var order in orders) order.Display();

        // Bubble Sort
        Order[] bubbleSorted = (Order[])orders.Clone();
        OrderSorting.BubbleSort(bubbleSorted);
        Console.WriteLine("\nBubble Sorted Orders:");
        foreach (var order in bubbleSorted) order.Display();

        // Quick Sort
        Order[] quickSorted = (Order[])orders.Clone();
        OrderSorting.QuickSort(quickSorted, 0, quickSorted.Length - 1);
        Console.WriteLine("\nQuick Sorted Orders:");
        foreach (var order in quickSorted) order.Display();
    }
}
