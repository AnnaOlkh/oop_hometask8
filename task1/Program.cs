using System;
using System.Collections.Generic;
using System.Linq;
//порушується інкапуляція та принцип єдиної відповідальності
class Item
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Item(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}

class Order
{
    private List<Item> itemList;

    public Order()
    {
        itemList = new List<Item>();
    }

    public void AddItem(Item item)
    {
        if (item != null)
        {
            itemList.Add(item);
        }
    }

    public void RemoveItem(Item item)
    {
        if (item != null && itemList.Contains(item))
        {
            itemList.Remove(item);
        }
    }
    public IReadOnlyList<Item> GetItems()
    {
        return itemList.AsReadOnly();
    }
    public decimal CalculateTotalSum()
    {
        return itemList.Sum(item => item.Price * item.Quantity);
    }

    public void PrintOrder()
    {
        Console.WriteLine("Order Summary:");
        foreach (var item in itemList)
        {
            Console.WriteLine($"- {item.Name}: {item.Quantity} x {item.Price} грн = {item.Quantity * item.Price} грн");
        }
        Console.WriteLine($"Total: {CalculateTotalSum()} грн");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var order = new Order();
        var item1 = new Item("Orange", 1.5m, 4);
        var item2 = new Item("Cookies", 3.0m, 2);
        var item3 = new Item("Tomatoes", 2.5m, 6);

        order.AddItem(item1);
        order.AddItem(item2);
        order.AddItem(item3);

        order.PrintOrder();

        order.RemoveItem(item2);
        Console.WriteLine("After removing an item:");
        order.PrintOrder();
    }
}
