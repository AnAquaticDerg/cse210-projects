using System.Text.Json.Serialization;


public class Scripture
{
    [JsonInclude]
    private List<string> _displayedScripture;
    [JsonInclude]
    private List<ScriptureWord> _logicScripture;
    [JsonInclude]
    private List<ScriptureWord> _memoryScripture; 
    [JsonInclude]
    private ScriptureReference _reference = new ScriptureReference();

    private void DisplayScripture()
    {
        Console.Clear();
        Console.WriteLine(_reference.GetReference());
        int count = 0;
        foreach (string word in _displayedScripture)
        {
            if (count % 10 == 0)
            {
                Console.WriteLine();
            }
            Console.Write($"{word} ");
            count += 1;
        }
        Console.WriteLine();
    }

    private void HideRandomWord()
    {
        Random randomIndexSeed = new Random();
        int randomIndex = randomIndexSeed.Next(_logicScripture.Count);

        ScriptureWord randomWord = _logicScripture[randomIndex];
        string hiddenWord = randomWord.HideWord();
        int index = _displayedScripture.IndexOf(randomWord.GetWord());

        _displayedScripture[index] = hiddenWord;
        _logicScripture.Remove(randomWord);
    }

    private void ResetScripture()
    {
        _displayedScripture = new List<string>();
        _logicScripture = new List<ScriptureWord>();

        foreach (ScriptureWord scripWord in _memoryScripture)
        {
            _displayedScripture.Add(scripWord.GetWord());
            _logicScripture.Add(scripWord);
        }
    }

    public void MemorizeScripture()
    {

        string userResponse;
        do
        {
            DisplayScripture();

            Random randomAmountSeed = new Random();
            int randomAmount = randomAmountSeed.Next(3) + 1;
            if (randomAmount > _logicScripture.Count)
            {
                randomAmount = _logicScripture.Count;
            }
            while (randomAmount > 0)
            {
                HideRandomWord();
                randomAmount -= 1;
            }

            Console.WriteLine("\nEnter anything to continue, but enter \"Q\" to quit.");
            userResponse = Console.ReadLine().ToLower();

        } while (_logicScripture.Count != 0 && userResponse != "q");

        DisplayScripture();
        ResetScripture();
    }

    public void SetScripture(string scriptureString, string gospel, string chapter, string startVerse, string endVerse)
    {
        _displayedScripture = new List<string>();
        _logicScripture = new List<ScriptureWord>();
        _memoryScripture = new List<ScriptureWord>();

        List<string> scriptureStringList = scriptureString.Split(' ').ToList();
        List<ScriptureWord> scriptureWordsList = new List<ScriptureWord>();

        foreach (string word in scriptureStringList)
        {
            ScriptureWord scripWord = new ScriptureWord(word);
            scriptureWordsList.Add(scripWord);

            _displayedScripture.Add(scripWord.GetWord());
            _logicScripture.Add(scripWord);
            _memoryScripture.Add(scripWord);
        }
        
        if (startVerse == "")
        {
            _reference = new ScriptureReference(gospel, chapter);
        }
        else if (endVerse == "")
        {
            _reference = new ScriptureReference(gospel, chapter, startVerse);
        }
        else
        {
            _reference = new ScriptureReference(gospel, chapter, startVerse, endVerse);
        }
    }

    public void ShowReference()
    {
        Console.WriteLine(_reference.GetReference());
    }

    public string ReturnReference()
    {
        return  _reference.GetReference();
    }
}