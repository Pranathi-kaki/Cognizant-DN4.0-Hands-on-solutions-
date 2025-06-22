using System;
using System.Collections.Generic;

// Product class
public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public Product(int id, string name, int qty, double price)
    {
        ProductId = id;
        ProductName = name;
        Quantity = qty;
        Price = price;
    }

    public void Display()
    {
        Console.WriteLine($"ID: {ProductId}, Name: {ProductName}, Qty: {Quantity}, Price: ₹{Price}");
    }
}

// Inventory Manager
public class Inventory
{
    private Dictionary<int, Product> products = new Dictionary<int, Product>();

    public void AddProduct(Product product)
    {
        if (!products.ContainsKey(product.ProductId))
        {
            products.Add(product.ProductId, product);
            Console.WriteLine("Product added.");
        }
        else
        {
            Console.WriteLine("Product ID already exists.");
        }
    }

    public void UpdateProduct(int id, string newName, int newQty, double newPrice)
    {
        if (products.ContainsKey(id))
        {
            products[id].ProductName = newName;
            products[id].Quantity = newQty;
            products[id].Price = newPrice;
            Console.WriteLine("Product updated.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    public void DeleteProduct(int id)
    {
        if (products.Remove(id))
        {
            Console.WriteLine("Product deleted.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    public void ShowAllProducts()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("Inventory is empty.");
        }
        else
        {
            foreach (var item in products.Values)
            {
                item.Display();
            }
        }
    }
}

// Main class
public class InventorySystem
{
    public static void Main(string[] args)
    {
        Inventory inv = new Inventory();

        inv.AddProduct(new Product(101, "Mouse", 20, 299.99));
        inv.AddProduct(new Product(102, "Keyboard", 15, 499.50));

        inv.ShowAllProducts();

        inv.UpdateProduct(101, "Wireless Mouse", 25, 349.99);
        inv.DeleteProduct(102);

        inv.ShowAllProducts();
    }
}
