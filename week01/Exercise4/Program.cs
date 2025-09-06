using System;

class Program
{
    static void Main(string[] args)
    {
        List<double> numbers = new List<double>();
        double numberInput = -1;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter number: ");
            string userInput = Console.ReadLine();

            if (double.TryParse(userInput, out numberInput))
            {

                if (numberInput != 0)
                {
                    numbers.Add(numberInput);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");

                numberInput = -1; 
            }
        } while (numberInput != 0);

        if (numbers.Count == 0)
        {
            Console.WriteLine("The list is empty. No calculations to perform.");
            return;
        }

        double sum = 0;
        foreach (double number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        double average = sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        double maxNumber = numbers[0];
        foreach (double number in numbers)
        {
            if (number > maxNumber)
            {
                maxNumber = number;
            }
        }
        Console.WriteLine($"The largest number is: {maxNumber}");

        double smallestPositive = double.MaxValue;
        bool foundPositive = false;
        foreach (double number in numbers)
        {
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
                foundPositive = true;
            }
        }
        if (foundPositive)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("There are no positive numbers in the list.");
        }

        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (double number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}