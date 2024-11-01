using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        int number;

        Console.WriteLine("Enter a series of numbers. Enter 0 to stop:");

        // Collected numbers from the user until they enter 0
        do
        {
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }

        } while (number != 0);

        if (numbers.Count > 0)
        {
            int sum = numbers.Sum();
            double average = numbers.Average();
            int max = numbers.Max();

            Console.WriteLine($"Total sum: {sum}");
            Console.WriteLine($"Average: {average}");
            Console.WriteLine($"Maximum number: {max}");
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}
