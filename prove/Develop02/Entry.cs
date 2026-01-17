using System.Runtime.CompilerServices;

public class Entry
{
    public DateTime _dateWritten  { get; set; }
    public string _entry { get; set; }
    private Random _random = new Random();

    public string PromptForResponse(List<string> prompts)
    {
        try
        {
            string usedPrompt = prompts[_random.Next(prompts.Count())];
            prompts.Remove(usedPrompt);

            Console.WriteLine("\n"+usedPrompt);
            string userResponse = Console.ReadLine();

            Console.WriteLine("\nAnd how are you feeling right now?");
            string userMood = Console.ReadLine();

            _dateWritten = DateTime.Now;

            string textEntry = usedPrompt + "\n" + userResponse + "\nMood: " + userMood;
            return textEntry;   
        }
        catch (ArgumentOutOfRangeException)
        {
            prompts = new List<string>
            {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
            };

            string textEntry = PromptForResponse(prompts);
            return textEntry;
        }
        
    }
}