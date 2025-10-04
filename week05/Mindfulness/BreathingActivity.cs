using System;

public class BreathingActivity : Activity
{

    public BreathingActivity()
    {
    }

    public void Run()
    {
        DisplayStartingMessage(
            "Breathing Activity",
            "This activity will help you relax by guiding you through slow, deliberate breathing."
        );

        Console.WriteLine("Get ready...");
        ShowSpinner(3);

        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < Duration)
        {
            if ((DateTime.Now - startTime).TotalSeconds + 10 > Duration)
            {
                break;
            }
            
            Console.Write("\nBreathe in...");
            ShowCountDown(4);

            Console.Write("\nBreathe out...");
            ShowCountDown(6);
        }

        DisplayEndingMessage();
    }
}