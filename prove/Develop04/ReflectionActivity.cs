using static DeluxeConsole;
public class ReflectionActivity : Activity
{
    private List<string> _startingPrompts;
    private List<string> _followingPrompts;
    private Random _random = new Random();

    public ReflectionActivity(List<string> startingPrompts, List<string> followingPrompts) : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _startingPrompts = startingPrompts;
        _followingPrompts = followingPrompts;
    }

    public void Reflect()
    {
        GreetUser();

        WriteLineDeluxe($"\n{_startingPrompts[_random.Next(_startingPrompts.Count())]}");
        DisplaySpinner();

        _followingPrompts = _followingPrompts.OrderBy(x => _random.Next()).ToList();
        int i = 0;
        
        while (GetEndTime() > DateTime.Now)
        {
            WriteLineDeluxe(_followingPrompts[i]);
            DisplaySpinner(7);

            i++;

            if (i >= _followingPrompts.Count())
            {
                _followingPrompts = _followingPrompts.OrderBy(x => _random.Next()).ToList();

                i = 0;
            }
        }

        BidFarewell();        
    }
}