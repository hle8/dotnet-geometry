using System.Collections;
using GeometryCalc.Library.Shapes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

namespace GeometryCalc.Program;

static class Program
{
    static async Task Main()
    {
        var featureManagement = new Dictionary<string, string>
        {
            { "FeatureManagement:Square", "true" },
            { "FeatureManagement:Rectangle", "false" },
            { "FeatureManagement:Triangle", "true" }
        };

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(featureManagement)
            .Build();

        var services = new ServiceCollection();
        services.AddFeatureManagement(configuration);
        var serviceProvider = services.BuildServiceProvider();

        var featureManager = serviceProvider.GetRequiredService<IFeatureManager>();

        while (true)
        {
            Console.WriteLine("Geometry Calculator");
            Console.WriteLine("===================");

            if (await featureManager.IsEnabledAsync("Square"))
            {
                Console.WriteLine("1. Square");
            }
            if (await featureManager.IsEnabledAsync("Rectangle"))
            {
                Console.WriteLine("2. Rectangle");
            }
            if (await featureManager.IsEnabledAsync("Triangle"))
            {
                Console.WriteLine("3. Triangle");
            }
            Console.WriteLine("0. Exit");

            Console.Write("\nYour choice: ");
            var selection = Console.ReadLine();

            switch (selection)
            {
                case "0":
                    Console.WriteLine("Good bye!!!");
                    return;
                case "1":
                    if (await featureManager.IsEnabledAsync("Square"))
                    {
                        Console.Write("Enter length: ");

                        var _square = new Square(Convert.ToDouble(Console.ReadLine()));

                        Console.WriteLine($"Perimeter: {_square.CalculatePerimeter()}");
                        Console.WriteLine($"Area: {_square.CalculateArea()}");
                    }
                    else
                        Console.WriteLine("Oops! Invalid option");
                    break;
                case "2":
                    if (await featureManager.IsEnabledAsync("Rectangle"))
                    {
                        Console.Write("Enter length: ");
                        var length = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter width: ");
                        var width = Convert.ToDouble(Console.ReadLine());

                        var _rectangle = new Rectangle(length, width);

                        Console.WriteLine($"Perimeter: {_rectangle.CalculatePerimeter()}");
                        Console.WriteLine($"Area: {_rectangle.CalculateArea()}");
                    }
                    else
                        Console.WriteLine("Oops! Invalid option");
                    break;
                case "3":
                    if (await featureManager.IsEnabledAsync("Triangle"))
                    {
                        Console.Write("Enter right side: ");
                        var rightSide = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter left side: ");
                        var leftSide = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter bottom side: ");
                        var bottomSide = Convert.ToDouble(Console.ReadLine());

                        var _triangle = new Triangle(rightSide, leftSide, bottomSide);

                        Console.WriteLine($"Perimeter: {_triangle.CalculatePerimeter()}");
                        Console.WriteLine($"Area: {Math.Round(_triangle.CalculateArea(), 3)}");
                    }
                    else
                        Console.WriteLine("Oops! Invalid option");
                    break;
                default:
                    Console.WriteLine("Oops! Invalid option");
                    break;
            }

            Console.WriteLine("");

            bool next = true;
            while (next)
            {
                Console.Write("Continue (y/n)? ");
                var answer = Console.ReadLine();

                switch (answer)
                {
                    case "y":
                        next = false;
                        break;
                    case "n":
                        Console.WriteLine("Good bye!!!");
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
