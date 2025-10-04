using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity()
    {
        _name = "Generic Activity";
        _description = "A standard activity.";
        _duration = 0;
    }

    public int Duration
    {
        get { return _duration; }
        protected set { _duration = value; }
    }

    public void DisplayStartingMessage(string name, string description)
    {
        _name = name;
        _description = description;

        Console.WriteLine($"\n--- Starting {_name} ---");
        Console.WriteLine($"{_description}");
        Console.Write("Enter the duration in seconds: ");

        if (int.TryParse(Console.ReadLine(), out int durationInput) && durationInput > 0)
        {
            _duration = durationInput;
        }
        else
        {
            Console.WriteLine("Invalid duration entered. Defaulting to 30 seconds.");
            _duration = 30;
        }

        Console.WriteLine($"\nPrepare to begin for {_duration} seconds...");
        ShowCountDown(3); 
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nGood job!");
        ShowSpinner(3); 
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        ShowCountDown(3);
        Console.WriteLine("------------------------------------------");
    }

    public void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string> { "/", "-", "\\", "|" };
        DateTime startTime = DateTime.Now;
        int i = 0;
        while ((DateTime.Now - startTime).TotalSeconds < seconds)
        {
            Console.Write(spinner[i % spinner.Count]);
            Thread.Sleep(250); 
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            i++;
        }
        Console.Write(" ");
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000); 
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
        Console.Write(" ");
    }
}