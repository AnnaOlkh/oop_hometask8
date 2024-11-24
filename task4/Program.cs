using System;

/*Даний інтерфейс поганий тим, що він включає занадто багато методів.
 А що, якщо наш клас товарів не може мати знижок або промокодом, або для нього немає сенсу встановлювати матеріал з 
 якого зроблений (наприклад, для книг). Таким чином, щоб не реалізовувати в кожному класі невикористовувані в ньому методи, краще 
розбити інтерфейс на кілька дрібних і кожним конкретним класом реалізовувати потрібні інтерфейси.
Перепишіть, розбивши інтерфейс на декілька інтерфейсів, керуючись принципом розділення інтерфейсу. 
Опишіть класи книжки (розмір та колір не потрібні, але потрібна ціна та знижки) та верхній одяг (колір, розмір, ціна знижка),
які реалізують притаманні їм інтерфейси.*/
//принцип розділення інтерфейсу
interface IPriceable
{
    void SetPrice(double price);
}

interface IDiscountable
{
    void ApplyDiscount(string discount);
    void ApplyPromocode(string promocode);
}
interface ICustomizable
{
    void SetColor(string color);
    void SetSize(string size);
}
class Book : IPriceable, IDiscountable
{
    private double price;
    private string discount;
    private string promocode;

    public void SetPrice(double price)
    {
        this.price = price;
        Console.WriteLine($"Book price set to {price}");
    }

    public void ApplyDiscount(string discount)
    {
        this.discount = discount;
        Console.WriteLine($"Discount '{discount}' applied to the book");
    }

    public void ApplyPromocode(string promocode)
    {
        this.promocode = promocode;
        Console.WriteLine($"Promocode '{promocode}' applied to the book");
    }
}
class Furniture : IPriceable, IDiscountable, ICustomizable
{
    private double price;
    private string discount;
    private string promocode;
    private string color;
    private string size;

    public void SetPrice(double price)
    {
        this.price = price;
        Console.WriteLine($"Furniture price set to {price}");
    }

    public void ApplyDiscount(string discount)
    {
        this.discount = discount;
        Console.WriteLine($"Discount '{discount}' applied to the furniture");
    }

    public void ApplyPromocode(string promocode)
    {
        this.promocode = promocode;
        Console.WriteLine($"Promocode '{promocode}' applied to the furniture");
    }

    public void SetColor(string color)
    {
        this.color = color;
        Console.WriteLine($"Furniture color set to {color}");
    }

    public void SetSize(string size)
    {
        this.size = size;
        Console.WriteLine($"Furniture size set to {size}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Book book = new Book();
        book.SetPrice(15.99);
        book.ApplyDiscount("10%");
        book.ApplyPromocode("BOOK2024");

        Console.WriteLine();

        Furniture chair = new Furniture();
        chair.SetPrice(99.99);
        chair.ApplyDiscount("20%");
        chair.ApplyPromocode("FURN2024");
        chair.SetColor("Black");
        chair.SetSize("Medium");

        Console.ReadKey();
    }
}
