using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity()
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you saw God's hand in your life recently."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage(
            "Reflecting Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience."
        );

        Console.WriteLine("Get ready...");
        ShowSpinner(3);

        DisplayPrompt();
        
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();

        DisplayQuestions();
        
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine($"\nConsider the following prompt:\n\n--- {GetRandomPrompt()} ---\n");
    }

    public void DisplayQuestions()
    {
        DateTime startTime = DateTime.Now;
        Console.WriteLine("Now ponder each of the following questions as you continue to reflect (focus on one at a time).");

        while ((DateTime.Now - startTime).TotalSeconds < Duration)
        {
            Console.WriteLine($"> {GetRandomQuestion()}");

            int timeForReflection = 8;

            if ((DateTime.Now - startTime).TotalSeconds + timeForReflection > Duration)
            {
                timeForReflection = (int)(Duration - (DateTime.Now - startTime).TotalSeconds);
            }
            
            ShowSpinner(timeForReflection); 

            if ((DateTime.Now - startTime).TotalSeconds >= Duration) break;

            Console.WriteLine();
        }
    }
}