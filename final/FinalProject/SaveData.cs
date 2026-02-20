using System.Text.Json.Serialization;

public class SaveData
{
    [JsonInclude]
    private List<Character> _characters;
    [JsonInclude]
    private List<Enemy> _enemies;

    public List<Character> GetCharacters()
    {
        return _characters;
    }
    public List<Enemy> GetEnemies()
    {
        return _enemies;
    }
    public void UpdateData(List<Character> characters, List<Enemy> enemies)
    {
        _characters = characters;
        _enemies = enemies;
    }
}