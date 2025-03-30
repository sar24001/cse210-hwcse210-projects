using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries = new List<Entry>();
    private List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I could do one more thing today, what would it be?"
    };

    public void AddEntry()
    {
        Random rnd = new Random();
        string prompt = prompts[rnd.Next(prompts.Count)];
        Console.WriteLine($"Question: {prompt}");
        Console.Write("Answer: ");
        string response = Console.ReadLine();

        entries.Add(new Entry(prompt, response));
        Console.WriteLine("Entry added.\n");
    }

    public void DisplayEntries()
    {
        Console.WriteLine("\n--- Journal Entries ---");
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
        Console.WriteLine();
    }

    public void SaveToFile()
    {
        Console.Write("Enter the file name to save: ");
        string fileName = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date}~{entry.Prompt}~{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved.\n");
    }

    public void LoadFromFile()
    {
        Console.Write("Enter the file name to load: ");
        string fileName = Console.ReadLine();

        if (File.Exists(fileName))
        {
            entries.Clear();
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] parts = line.Split('~');
                if (parts.Length == 3)
                {
                    entries.Add(new Entry(parts[1], parts[2]) { Date = parts[0] });
                }
            }
            Console.WriteLine("Journal loaded.\n");
        }
        else
        {
            Console.WriteLine("File not found.\n");
        }
    }
}
