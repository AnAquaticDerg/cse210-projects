using System.Threading.Channels;

public class CharacterSet
{
    private List<Character> _characters;
    private List<Enemy> _enemies;
    private Random _random = new Random();

    public List<Character> GetCharacters()
    {
        return _characters;
    }
    public List<Enemy> GetEnemies()
    {
        return _enemies;
    }
    public void SaveCharacters() {}
    public void LoadCharacters() {}
} 