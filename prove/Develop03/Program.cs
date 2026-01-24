class Program
/*
To show creativity and exceed the requirements, I have:
• Only hidden non-hidden words
• Made a library for multiple scriptures
• Made them selectable via reference (and validated input)
• Serialized and deserialzed the dictionary whilst maintaining encapulation
• Made it quite difficult to flag an error
*/
{
    static void Main(string[] args)
    {
        ScriptureLibrary scriptureLibrary = new ScriptureLibrary();
        string menuResponse;

        do
        {
            Console.WriteLine("\nWhat would you like to do:\nAdd a scripture [A]\nMemorize a scripture [M]\nSave the current library [S]\nLoad the library from a file [L]\nQuit [Q]");
            menuResponse = Console.ReadLine().ToLower();
            if (menuResponse == "a")
            {
                scriptureLibrary.AddScripture();
            }
            else if (menuResponse == "m")
            {
                scriptureLibrary.ViewScriptures();
            }
            else if (menuResponse == "s")
            {
                scriptureLibrary.SaveLibrary();
            }
            else if (menuResponse == "l")
            {
                scriptureLibrary.LoadLibrary();
            }
            else if (menuResponse == "q")
            {
                Console.WriteLine("Hope you grew spiritually during your study!");
            }
        } while (menuResponse != "q");
    }
}

