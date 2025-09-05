using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain;
        do
        {

            int magicNumber;
            do
            {
                Console.Write("What is the magic number? ");
                string userInput = Console.ReadLine();
                
                if (!int.TryParse(userInput, out magicNumber))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            } while (magicNumber == 0); 

            int guessCount = 0;
            int userGuess = -1; 

            while (userGuess != magicNumber)
            {

                Console.Write("What is your guess? ");
                string userInput = Console.ReadLine();

                guessCount++;

                if (!int.TryParse(userInput, out userGuess))
                {
                    Console.WriteLine("Invalid input. Please enter a whole number.");

                    guessCount--;
                    continue;
                }

                if (userGuess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (userGuess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            Console.WriteLine($"It took you {guessCount} guesses.");

            Console.Write("Do you want to play again? (yes/no) ");
            playAgain = Console.ReadLine();

        } while (playAgain.ToLower() == "yes");

        Console.WriteLine("Thanks for playing! Goodbye.");
    }
}