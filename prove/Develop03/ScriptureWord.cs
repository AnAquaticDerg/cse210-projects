using System.Text.Json.Serialization;

public class ScriptureWord
{
    [JsonInclude]
    private string _word;

    public ScriptureWord()
    {
        _word = "";
    }
    public ScriptureWord(string word)
    {
        _word = word;
    }

    public string GetWord()
    {
        return _word;
    }
    public string HideWord()
    {
    string hiddenWord = "";
    foreach (char ch in _word) 
    {
        hiddenWord += "_";
    }
    return hiddenWord;
    }
}