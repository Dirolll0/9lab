﻿using System;

abstract class Shape
{
    public abstract double Area();

    public virtual void DisplayInfo()
    {
        Console.WriteLine("Это фигура.");
    }
}

abstract class Quadrilateral : Shape
{
    public Quadrilateral()
    {
        Console.WriteLine("Создан 4-х угольник.");
    }

    ~Quadrilateral()
    {
        Console.WriteLine("Уничтожен 4-х угольник.");
    }
}

abstract class Triangle : Shape
{
    public Triangle()
    {
        Console.WriteLine("Создан треугольник.");
    }

    ~Triangle()
    {
        Console.WriteLine("Уничтожен треугольник.");
    }
}

class Square : Quadrilateral
{
    double side;

    public Square(double side)
    {
        this.side = side;
        Console.WriteLine("Создан квадрат.");
    }
    ~Square()
    {
        Console.WriteLine("Уничтожен квадрат.");
    }

    public override double Area()
    {
        return side * side;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("Это квадрат со стороной {0}.", side);
    }
}
class IsoscelesTriangle : Triangle
{
    double baseLength;
    double height;

    public IsoscelesTriangle(double baseLength, double height)
    {
        this.baseLength = baseLength;
        this.height = height;
        Console.WriteLine("Создан равнобедренный треугольник.");
    }

    ~IsoscelesTriangle()
    {
        Console.WriteLine("Уничтожен равнобедренный треугольник.");
    }

    public override double Area()
    {
        return 0.5 * baseLength * height;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("Это равнобедренный треугольник с основанием {0} и высотой {1}.", baseLength, height);
    }
}

class RightTriangle : Triangle
{
    double baseLength;
    double height;

    public RightTriangle(double baseLength, double height)
    {
        this.baseLength = baseLength;
        this.height = height;
        Console.WriteLine("Создан прямоугольный треугольник.");
    }
    ~RightTriangle()
    {
        Console.WriteLine("Уничтожен прямоугольный треугольник.");
    }

    public override double Area()
    {
        return 0.5 * baseLength * height;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("Это прямоугольный треугольник с основанием {0} и высотой {1}.", baseLength, height);
    }
}

class EquilateralTriangle : Triangle
{
    double side;

    public EquilateralTriangle(double side)
    {
        this.side = side;
        Console.WriteLine("Создан равносторонний треугольник.");
    }

    ~EquilateralTriangle()
    {
        Console.WriteLine("Уничтожен равносторонний треугольник.");
    }

    public override double Area()
    {
        return (Math.Sqrt(3) / 4) * side * side;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("Это равносторонний треугольник со стороной {0}.", side);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Shape[] shapes = new Shape[4];
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine($"Введите параметры для фигуры {i + 1}:");
         T1:   Console.Write("Сторона/Основание: ");
            if (double.TryParse(Console.ReadLine(), out double param1) && param1 > 0)
            { }
            else
            {
                Console.WriteLine("Введено некоректное значение");
                goto T1;
            }
            Console.Write("Высота: ");
         T2:   if (double.TryParse(Console.ReadLine(), out double param2) && param2 > 0)
            { }
            else
            {
                Console.WriteLine("Введено некоректное значение");
                goto T2;
            }

            switch (i)
            {
                case 0:
                    shapes[i] = new Square(param1);
                    break;
                case 1:
                    shapes[i] = new IsoscelesTriangle(param1, param2);
                    break;
                case 2:
                    shapes[i] = new RightTriangle(param1, param2);
                    break;
                case 3:
                    shapes[i] = new EquilateralTriangle(param1);
                    break;
            }
        }


        foreach (var shape in shapes)
        {
            Console.WriteLine($"Площадь фигуры: {shape.Area()}");
            shape.DisplayInfo();
            Console.WriteLine();
        }
    }
}