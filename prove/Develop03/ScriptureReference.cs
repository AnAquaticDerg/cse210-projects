using System.Text.Json.Serialization;

public class ScriptureReference
{
    [JsonInclude]
    private string _book;
    [JsonInclude]
    private string _chapter;
    [JsonInclude]
    private string _startVerse;
    [JsonInclude]
    private string _endVerse;

    public ScriptureReference()
    {
        _book = "";
        _chapter = "";
        _startVerse = "";
        _endVerse = "";
    }
    public ScriptureReference(string book, string chapter)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = "";
        _endVerse = "";
    }
    public ScriptureReference(string book, string chapter, string startVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = "";
    }
    public ScriptureReference(string book, string chapter, string startVerse, string endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public string GetReference()
    {
        if (_chapter == "")
        {
            return _book;
        }
        else if (_startVerse == "")
        {
            return _book + " " + _chapter;    
        }
        else if (_endVerse == "")
        {
            return _book + " " + _chapter + ":" + _startVerse;    
        }
        else
        {
            return _book + " " + _chapter + ":" + _startVerse + "-" + _endVerse;    
        }
    }

}