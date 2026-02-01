using static DeluxeConsole;
public class ListingActivity : Activity
{
    private List<string> _prompts;
    private Random _random = new Random();

    public ListingActivity(List<string> prompts) : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = prompts;
    }

    public void ListThings()
    {
        GreetUser();

        WriteLineDeluxe($"\n{_prompts[_random.Next(_prompts.Count())]}");
        WaitWithPrompt("Get ready to list items...");
        Console.WriteLine();

        int count = 0;
        while (GetEndTime() > DateTime.Now)
        {
            Console.ReadLine();
            count += 1;
        }

        Console.WriteLine($"\nYou listed {count} things! Great job!");
        DisplaySpinner(3);

        BidFarewell();
    }
}