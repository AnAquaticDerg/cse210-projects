using System;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        string menuResponse;
        List<string> prompts = new List<string>
        {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What am I most grateful for?",
        "What was your most unforgettable connection?",
        "Who do you love the most and why?",
        "What makes you feel confident, or what would make you feel more confident?",
        "What's standing between you and happiness?",
        "What makes you happy?",
        "What are you most fearful of?",
        "In an ideal world, who would you want to be?",
        "What is your idea of peace?",
        "How do you regulate your emotions. Is this method serving you? Why or why not?",
        "What triggers you most and why?",
        "What emotions do you tend to deny or ignore and why?",
        "Can you give yourself permission to release feelings and emotions that no longer server you? Why or why not?",
        "What are your biggest goals and dreams?",
        "How would you spend your last day on earth?",
        "Write about one of your favorite days from your childhood/past:",
        "Name someone you look up to. What do you admire about them?",
        "List all the things you're grateful for about this last year.",
        "If you could change one thing about yourself, what would it be and why?",
        "Which area of your life do you think receives the most attention, and which area receives the least? Would you change this imbalence?",
        "What is the primary emotion or feeling you experience on a daily basis?",
        "What does your ideal day look like?",
        "What habit would you most like to break? And what habit would you most like to make?",
        "When was the last time you did something you were afraid of?",
        "What is an important life lesson you have learned recently?",
        "What would you do if you knew you couldn't fail?"
        };

        Console.WriteLine("\n\nHello! Welcome to QuickJot, your personal tool for making journaling quick and easy!\nWho is journaling right now?");
        string baseName = Console.ReadLine();
        myJournal._name = char.ToUpper(baseName[0]) + baseName.Substring(1).ToLower();

        Console.WriteLine($"\nWelcome {myJournal._name}! What file will we use for saving and loading? (Exclude the file extension)");
        myJournal._filename = Console.ReadLine().ToLower() + ".json";
        myJournal._entries = myJournal.LoadJournal(ref myJournal._filename);
        Console.WriteLine($"Great! \"{myJournal._filename}\" it is!");

        do
        {
            Console.WriteLine("\nWhat would you like to do:\nAdd an entry [A]\nView entries [V]\nSave your journal [S]\nLoad the journal from the current file [L]\nQuit [Q]");
            menuResponse = Console.ReadLine().ToLower();
            if (menuResponse == "a")
            {
                myJournal.AddEntry(prompts);
            }
            if (menuResponse == "v")
            {
                myJournal.DisplayEntries();
            }
            if (menuResponse == "s")
            {
                myJournal.SaveJournal(myJournal._filename);
            }
            if (menuResponse == "l")
            {
                myJournal._entries = myJournal.LoadJournal(ref myJournal._filename);
            }
            if (menuResponse == "q")
            {
                Console.WriteLine("Have a great day!");
            }
        } while (menuResponse != "q");
    }
}