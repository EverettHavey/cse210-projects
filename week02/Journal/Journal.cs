using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{

    public List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }


    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    // Saves the journal to JSON
    public void SaveToFile(string file)
    {
        try
        {

            string jsonString = JsonSerializer.Serialize(_entries);

            File.WriteAllText(file, jsonString);
            Console.WriteLine($"Journal saved to {file} successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving the file: {ex.Message}");
        }
    }

    // Loads the journal from JSON
    public void LoadFromFile(string file)
    {
        try
        {

            string jsonString = File.ReadAllText(file);


            _entries = JsonSerializer.Deserialize<List<Entry>>(jsonString);
            Console.WriteLine($"Journal loaded from {file} successfully.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: The file '{file}' was not found.");
        }
        catch (JsonException)
        {
            Console.WriteLine($"Error: The file '{file}' is not a valid JSON format.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading the file: {ex.Message}");
        }
    }
}