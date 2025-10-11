using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private const string FILE_NAME = "goals.txt";

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        
        LoadGoals();
        
        bool running = true;
        while (running)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Record Event");
            Console.WriteLine("  4. Save Goals");
            Console.WriteLine("  5. Load Goals");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    LoadGoals();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
        Console.WriteLine("Goodbye!");
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYour current score is: {_score} points.");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("\nYour goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nGoal Details:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nSelect the type of goal to create:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter your choice: ");
        
        string choice = Console.ReadLine();
        
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        
        Console.Write("What is a short description? ");
        string description = Console.ReadLine();
        
        Console.Write("What is the amount of points associated with this goal? ");

        int points = int.Parse(Console.ReadLine()); 

        Goal newGoal = null;

        switch (choice)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine()); 
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine()); 
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid choice. Goal creation cancelled.");
                return;
        }

        if (newGoal != null)
        {
            _goals.Add(newGoal);
            Console.WriteLine($"Goal '{newGoal.GetName()}' created successfully!");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available to record an event.");
            return;
        }
        
        ListGoalNames();
        Console.Write("Which goal did you accomplish? (Enter the number) ");
        
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _goals.Count)
        {
            Goal goalToRecord = _goals[index - 1];

            bool wasCompleteBefore = goalToRecord.IsComplete();

            goalToRecord.RecordEvent();

            int pointsToAdd = 0;

            if (!wasCompleteBefore)
            {
                pointsToAdd += goalToRecord.GetPoints();

                if (goalToRecord is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
                {
                    pointsToAdd += checklistGoal.Bonus;
                }
            } 
            else if (goalToRecord is EternalGoal)
            {
                pointsToAdd += goalToRecord.GetPoints();
            }

            _score += pointsToAdd;
            DisplayPlayerInfo();
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    public void SaveGoals()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(FILE_NAME))
            {
                writer.WriteLine(_score);

                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine($"\nGoals successfully saved to {FILE_NAME}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        if (!File.Exists(FILE_NAME))
        {
            Console.WriteLine("\nNo saved file found. Starting with a blank slate.");
            _goals.Clear();
            _score = 0;
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(FILE_NAME);

            _goals.Clear();

            _score = int.Parse(lines[0]);
            
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(':');
                string goalType = parts[0];
                string[] data = parts[1].Split('|');

                Goal loadedGoal = null;

                string name = data[0];
                string description = data[1];
                int points = int.Parse(data[2]);

                switch (goalType)
                {
                    case "SimpleGoal":
                        bool isComplete = bool.Parse(data[3]);
                        loadedGoal = new SimpleGoal(name, description, points, isComplete);
                        break;
                        
                    case "EternalGoal":
                        loadedGoal = new EternalGoal(name, description, points);
                        break;
                        
                    case "ChecklistGoal":
                        int target = int.Parse(data[3]);
                        int bonus = int.Parse(data[4]);
                        int amountCompleted = int.Parse(data[5]);
                        loadedGoal = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
                        break;
                }

                if (loadedGoal != null)
                {
                    _goals.Add(loadedGoal);
                }
            }
            Console.WriteLine($"\nGoals successfully loaded from {FILE_NAME}.");
            DisplayPlayerInfo();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading: {ex.Message}. Starting fresh.");
            _goals.Clear();
            _score = 0;
        }
    }
}
