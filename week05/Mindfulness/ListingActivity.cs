using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity()
    {
        _count = 0;
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can."
        );

        Console.WriteLine("Get ready...");
        ShowSpinner(3);

        Console.WriteLine($"\nList as many items as you can in {Duration} seconds for the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        List<string> userList = GetListFromUser();
        _count = userList.Count;

        Console.WriteLine($"\nYou listed {_count} items.");
        
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public List<string> GetListFromUser()
    {
        List<string> userItems = new List<string>();
        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < Duration)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if ((DateTime.Now - startTime).TotalSeconds >= Duration)
            {
                break;
            }

            if (!string.IsNullOrWhiteSpace(item))
            {
                userItems.Add(item);
            }
        }
        return userItems;
    }
}