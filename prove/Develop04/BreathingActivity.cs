public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing."){}

    public void Breathe()
    {
        GreetUser();

        while (GetEndTime() > DateTime.Now)
        {
            WaitWithPrompt("\nBreathe in...", 4);
            WaitWithPrompt("Hold...", 4);
            WaitWithPrompt("Breathe out...", 4);
            WaitWithPrompt("Hold...", 4);
        }

        BidFarewell();
    }
}