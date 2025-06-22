using System;

public class Product
{
    public int? ProductId;
    public string? ProductName;
    public string? Category;

    public Product(int id, string name, string category)
    {
        ProductId = id;
        ProductName = name;
        Category = category;
    }

    public void Display()
    {
        Console.WriteLine($"ID: {ProductId}, Name: {ProductName}, Category: {Category}");
    }
}

public class ECommerceSearch
{
    public static Product? LinearSearch(Product[] products, string name)
    {
        foreach (var product in products)
        {
            if (product.ProductName.Equals(name, StringComparison.OrdinalIgnoreCase))
                return product;
        }
        return null;
    }

    public static Product BinarySearch(Product[] products, string name)
    {
        int low = 0;
        int high = products.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            int comparison = string.Compare(products[mid].ProductName, name, StringComparison.OrdinalIgnoreCase);

            if (comparison == 0)
                return products[mid];
            else if (comparison < 0)
                low = mid + 1;
            else
                high = mid - 1;
        }

        return null;
    }

    public static void Main(string[] args)
    {
        Product[] unsortedProducts = new Product[]
        {
            new Product(1, "Shoes", "Footwear"),
            new Product(2, "Laptop", "Electronics"),
            new Product(3, "Watch", "Accessories"),
            new Product(4, "Phone", "Electronics")
        };

        // Sorted for binary (by ProductName)
        Product[] sortedProducts = new Product[]
        {
            new Product(2, "Laptop", "Electronics"),
            new Product(4, "Phone", "Electronics"),
            new Product(1, "Shoes", "Footwear"),
            new Product(3, "Watch", "Accessories")
        };

        Console.WriteLine("Linear Search: Looking for 'Phone'");
        Product? found1 = LinearSearch(unsortedProducts, "Phone");
        if (found1 != null) found1.Display(); else Console.WriteLine("Product not found");

        Console.WriteLine("\nBinary Search: Looking for 'Phone'");
        Product? found2 = BinarySearch(sortedProducts, "Phone");
        if (found2 != null) found2.Display(); else Console.WriteLine("Product not found");
    }
}
