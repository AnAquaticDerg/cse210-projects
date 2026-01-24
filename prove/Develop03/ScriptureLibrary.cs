using System.Text.Json;
using System.Text.Json.Serialization;

public class ScriptureLibrary
{
    [JsonInclude]
    private Dictionary<string, Scripture> _scripturesDict = new Dictionary<string, Scripture>();

    public void ViewScriptures()
    {
        string chosenScripture;
        do
        {
            Console.WriteLine();
            foreach (var keyValuePair in _scripturesDict)
            {
                keyValuePair.Value.ShowReference();
            }
            Console.WriteLine("\nEnter a scripture reference to practice memorizing that scripture, or enter \"q\" to quit.");
            chosenScripture = Console.ReadLine().ToLower();
            if (chosenScripture != "q")
            {
                try
                {
                    Scripture scripture = _scripturesDict[chosenScripture];

                    scripture.MemorizeScripture();

                    Console.Clear();
                    Console.WriteLine("\nCongradulations! You finished memorizing that scripture!");
                }
                catch (KeyNotFoundException)
                {
                        Console.Write("There doesn't seem to be a scripture matching that reference... try again or enter \"q\" to go back.");
                }
            }
        } while (chosenScripture != "q");
    }

    public void AddScripture()
    {
        string passage = "";
        string book = "";
        string chapter = "";

        while (passage == "")
        {
        Console.WriteLine("\nPlease enter a scripture passage:");
        passage = Console.ReadLine();
        }

        while (book == "")
        {
        Console.WriteLine("\nPlease enter the book the passage is in (Matthew, Proverbs, etc.)");
        book = Console.ReadLine();
        }

        while (chapter == "")
        {
        Console.WriteLine("\nPlease enter the chapter the passage is in:");
        chapter = Console.ReadLine();
        }

        Console.WriteLine("\nPlease enter the first verse (leave blank if not applicable):");
        string startVerse = Console.ReadLine();

        Console.WriteLine("\nPlease enter the end verse (leave blank if not applicable):");
        string endVerse = Console.ReadLine();

        Scripture newScripture = new Scripture();
        newScripture.SetScripture(passage, book, chapter, startVerse, endVerse);

        _scripturesDict.Add(newScripture.ReturnReference().ToLower(), newScripture);
    }

    public void SaveLibrary()
    {
        string filename;
        Console.WriteLine("\nEnter the file name you would like to save your library to (exclude the file extension):");
        filename = Console.ReadLine().ToLower() + ".json";

        Console.WriteLine($"\nWould you like to save your changes to the file \"{filename}\"? (Y/N)");
        string userResponse = Console.ReadLine().ToLower();

        if (userResponse == "y")
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonLibraryDict = JsonSerializer.Serialize(_scripturesDict, options);
            File.WriteAllText(filename, jsonLibraryDict);

            Console.WriteLine($"Saved to \"{filename}\"");
        }
        else
        {
            Console.WriteLine("Understood.");
        }
    }

    public void LoadLibrary()
    {
        while (true)
        {
            string filename;
            Console.WriteLine("\nEnter the file name you would like to load a library from, or enter \"c\" to make a new one. (exclude the file extension):");
            filename = Console.ReadLine().ToLower() + ".json";

            if (filename != "c.json")
            {
                try
                {
                    var options = new JsonSerializerOptions
                    {
                        IncludeFields = true
                    };

                    var jsonLibraryDict = File.ReadAllText(filename);
                    Dictionary<string,Scripture> loadedLibraryDict = JsonSerializer.Deserialize<Dictionary<string,Scripture>>(jsonLibraryDict, options);

                    _scripturesDict = loadedLibraryDict;
                    Console.WriteLine("Loaded!");
                    return;
                }
                catch (FileNotFoundException)
                {
                Console.WriteLine($"\nSeems that this file doesn't exist.");
                }
            }
            else
            {
                Dictionary<string,Scripture> newLibrary = new Dictionary<string,Scripture>();
                _scripturesDict = newLibrary;
                Console.WriteLine("Created!");
                return;
            }
        }
    }
}