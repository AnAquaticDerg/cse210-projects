using System.IO.Enumeration;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

public class Journal
{
    public string _filename = "";
    public List<Entry> _entries = new List<Entry>();
    public string _name = "";

    public void AddEntry(List<string> prompts)
    {
        Entry newEntry = new Entry();

        Console.WriteLine("\nSimply respond to the prompts and hit enter when done.");
        newEntry._entry = newEntry.PromptForResponse(prompts);

        _entries.Add(newEntry);
        _entries.OrderBy(d=>d._dateWritten).ToList();
    }

    public void DisplayEntries()
    {
        Console.WriteLine("\nThis will show each journal entry in order of oldest to newest.\nEnter a page number to see that entry.");

        int pageOfInterest = 0; 
        do
        {
            try
            {
                Entry entryOfInterest = _entries[pageOfInterest];

                Console.WriteLine($"\n{_name}\t\t\t\t\t{entryOfInterest._dateWritten}");
                Console.WriteLine($"{entryOfInterest._entry}");

                Console.WriteLine($"\nPage {pageOfInterest+1}/{_entries.Count()}");
                Console.WriteLine("Enter a page number, and 0 when finished.");

                string pageString = Console.ReadLine();
                pageOfInterest = int.Parse(pageString)-1;
            }
            catch (ArgumentOutOfRangeException)
            {
                do
                {
                    Console.WriteLine("\nThat page does not exist. Try again.");
                    string pageString = Console.ReadLine();
                    pageOfInterest = int.Parse(pageString) - 1;
                } while (pageOfInterest > _entries.Count() || pageOfInterest < -1);
            }
        } while (pageOfInterest != -1);
    }

    public void SaveJournal(string filename)
    {
        Console.WriteLine($"\nWould you like to save your changes to the file \"{filename}\"? (Y/N)");
        string userResponse = Console.ReadLine().ToLower();
        if (userResponse == "y")
        {
            string jsonEntriesList = JsonSerializer.Serialize(_entries);
            File.WriteAllText(filename, jsonEntriesList);

            Console.WriteLine("Saved!");
        }
        else
        {
            Console.WriteLine("Understood.");
        }
    }

    public List<Entry> LoadJournal(ref string filename)
    {
        try
        {
            var jsonEntriesList = File.ReadAllText(filename);

            List<Entry> loadedEntriesList = JsonSerializer.Deserialize<List<Entry>>(jsonEntriesList);

            return loadedEntriesList;
        }
        catch (FileNotFoundException)
        {
        Console.WriteLine($"\nSeems that this file doesn't exist.");
        Console.WriteLine($"Try another file name, or enter [C] to create a new journal. (Exclude the file extension)");
        string fixResponse = Console.ReadLine().ToLower();
        if (fixResponse != "c")
        {
            filename = fixResponse + ".json";
            List<Entry> loadedEntriesList = LoadJournal(ref filename);
            return loadedEntriesList;
        }
        else
        {
            List<Entry> newJournal = new List<Entry>();
            return newJournal;
        }
        }
    }
}

