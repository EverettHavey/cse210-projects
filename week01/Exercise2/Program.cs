using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();

        double gradePercentage;
        
        if (!double.TryParse(userInput, out gradePercentage))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }

        string letterGrade = "";

        if (gradePercentage >= 90)
        {
            letterGrade = "A";
        }
        else if (gradePercentage >= 80)
        {
            letterGrade = "B";
        }
        else if (gradePercentage >= 70)
        {
            letterGrade = "C";
        }
        else if (gradePercentage >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        string sign = "";

        if (gradePercentage >= 60)
        {
            double lastDigit = gradePercentage % 10;
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        
        if (letterGrade == "A" && sign == "+")
        {
            sign = "";
        }

        if (letterGrade == "F")
        {
            sign = "";
        }

        Console.WriteLine($"Your grade is: {letterGrade}{sign}");

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't worry, you can do better next time! Keep working hard.");
        }
    }
}