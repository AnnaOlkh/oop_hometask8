//порушено принцип Liskov Substitution Principle (LSP)
//вирішення: розділити класи Square та Rectangle і створити спільний базовий клас або інтерфейс
using System;

abstract class Shape
{
    public abstract int GetArea();
}

class Rectangle : Shape
{
    public int Width { get; set; }
    public int Height { get; set; }

    public override int GetArea()
    {
        return Width * Height;
    }
}

class Square : Shape
{
    public int SideLength { get; set; }

    public override int GetArea()
    {
        return SideLength * SideLength;
    }
}

class Program
{
    static void Main(string[] args)
    {

        Rectangle rect = new Rectangle();
        rect.Width = 5;
        rect.Height = 10;

        Console.WriteLine(rect.GetArea());

        Square square = new Square();
        square.SideLength = 5;

        Console.WriteLine(square.GetArea());

        Console.ReadKey();
    }
}
