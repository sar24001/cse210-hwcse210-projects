using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ScriptureMemorizer;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // ----------------------------------------------------------------
            // Stretch Enhancements:
            // 1. Load multiple scriptures from "scriptures.json" and pick one at random.
            // 2. Track the number of iterations until the passage is fully hidden.
            // 3. Allow the user to type "reveal" to unhide one random word.
            // ----------------------------------------------------------------

            var scriptures = LoadScriptures("scriptures.json");
            if (scriptures.Count == 0)
            {
                var reference = new Reference("Proverbs", 3, 5);
                var text = "Trust in the Lord with all your heart and lean not on your own understanding ";
                scriptures.Add(new Scripture(reference, text));
            }

            var random = new Random();
            var scripture = scriptures[random.Next(scriptures.Count)];

            int roundCount = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to hide words, type 'reveal' to show one word, or type 'exit' to quit.");

                string input = Console.ReadLine()?.Trim().ToLower();
                if (input == "exit")
                    break;

                if (input == "reveal")
                {
                    scripture.RevealRandomWord();
                }
                else
                {
                    scripture.HideRandomWords(3);
                    roundCount++;
                }

                if (scripture.IsCompletelyHidden())
                {
                    Console.Clear();
                    Console.WriteLine(scripture.GetDisplayText());
                    Console.WriteLine($"\nAll words hidden in {roundCount} rounds. Press any key to finish.");
                    Console.ReadKey();
                    break;
                }
            }
        }

        // Loads a list of Scripture instances from a JSON file.
        private static List<Scripture> LoadScriptures(string filePath)
        {
            try
            {
                var json = File.ReadAllText(filePath);
                var dataList = JsonSerializer.Deserialize<List<ScriptureData>>(json);
                var scriptures = new List<Scripture>();

                foreach (var data in dataList)
                {
                    Reference reference;
                    if (data.StartVerse == data.EndVerse)
                        reference = new Reference(data.Book, data.Chapter, data.StartVerse);
                    else
                        reference = new Reference(data.Book, data.Chapter, data.StartVerse, data.EndVerse);

                    scriptures.Add(new Scripture(reference, data.Text));
                }

                return scriptures;
            }
            catch
            {
                return new List<Scripture>();
            }
        }

        // Helper DTO for JSON deserialization
        private class ScriptureData
        {
            public string Book { get; set; }
            public int Chapter { get; set; }
            public int StartVerse { get; set; }
            public int EndVerse { get; set; }
            public string Text { get; set; }
        }
    }
}
