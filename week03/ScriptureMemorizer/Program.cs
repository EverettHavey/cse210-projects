// Made it so it will work with a library of scriptures..
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptureLibrary = new List<Scripture>();

        Reference ref1 = new Reference("John", 3, 16);
        string text1 = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        scriptureLibrary.Add(new Scripture(ref1, text1));

        Reference ref2 = new Reference("Proverbs", 3, 5, 6);
        string text2 = "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        scriptureLibrary.Add(new Scripture(ref2, text2));

        Reference ref3 = new Reference("Mosiah", 4, 9);
        string text3 = "For behold, a wise man feeleth his way; a fool rushes in headlong.";
        scriptureLibrary.Add(new Scripture(ref3, text3));

        Random random = new Random();
        int randomIndex = random.Next(scriptureLibrary.Count);
        Scripture currentScripture = scriptureLibrary[randomIndex];

        while (!currentScripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(currentScripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to end.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            currentScripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(currentScripture.GetDisplayText());
        Console.WriteLine("\nAll words are now hidden. Program ended.");
    }
}