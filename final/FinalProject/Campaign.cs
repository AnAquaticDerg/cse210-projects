using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Channels;
using static DeluxeConsole;

public class Campaign
{
    private SaveData _saveData;
    private List<Character> _characters;
    private List<Enemy> _enemies;
    private Random _random = new Random();

    public Campaign()
    {
        _saveData = new SaveData();
        _characters = [];
        _enemies = [];
    }

    public List<Character> GetCharacters()
    {
        return _characters;
    }
    public List<Enemy> GetEnemies()
    {
        return _enemies;
    }
    
    public void MakeCharacter()
    {
        Console.Clear();

        WriteLineDeluxe("Assign your vessel a name.", 0);
        string characterName = Console.ReadLine();

        int characterType = -1;
        while (characterType > 5 || characterType < 0)
        {
            try
            {
                WriteLineDeluxe("\nNow determine their area of expertise.\n   1. Combat\n   2. Defense\n   3. Ranged attacks\n   4. Healing", 0);
                characterType = int.Parse(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                characterType = 0;
            }

            if (characterType == 1)
            {
                Fighter newCharacter = new Fighter(characterName);
                _characters.Add(newCharacter);
            }
            else if (characterType == 2)
            {
                Caster newCharacter = new Caster(characterName);
                _characters.Add(newCharacter);
            }
            else if (characterType == 3)
            {
                Ranger newCharacter = new Ranger(characterName);
                _characters.Add(newCharacter);
            }
            else if (characterType == 4)
            {
                Healer newCharacter = new Healer(characterName);
                _characters.Add(newCharacter);
            }

        }
        WriteLineDeluxe($"\nThe character \"{characterName}\" has been created.", 0);
    }
    public void MakeEnemy()
    {
        Console.Clear();

        WriteLineDeluxe("Assign the opponent a name.", 0);
        string enemyName = Console.ReadLine();

        WriteLineDeluxe("\nDetermine their level. Higher levels grant more XP, but can be much harder to defeat.", 0);
        int enemyLevel = int.Parse(Console.ReadLine());

        Enemy newEnemy = new Enemy(enemyName, enemyLevel);

        _enemies.Add(newEnemy);
        WriteLineDeluxe($"\nThe enemy \"{enemyName}\" has been created.", 0);
    }
    
    public void ViewParty()
    {
        Console.Clear();
        if (_characters.Count() == 0)
        {
            WriteLineDeluxe("It seems you don't have any characters. Try again when you have a party.");
        }
        else
        {
            WriteLineDeluxe("Your party:\n");
            foreach (Character character in _characters)
            {
                character.DisplayDetailedStats();
            }
        }
    }
    public void SaveCharacters()
    {
        WriteLineDeluxe("\nWhat file do you want to save your campaign to? (exclude file extension)");
        string filename = Console.ReadLine() + ".json";

        _saveData.UpdateData(_characters, _enemies);

        string jsonCampaignString = JsonSerializer.Serialize(_saveData);
        File.WriteAllText(filename, jsonCampaignString);

        WriteLineDeluxe($"\nCampaign saved to \"{filename}\"");
    }
    public void LoadCharacters()
    {
        try
        {
            WriteLineDeluxe("\nWhat file do you want to load your campaign from? (exclude the file extension)");
            string filename = Console.ReadLine() + ".json";

            string jsonCampaignString = File.ReadAllText(filename);
            SaveData saveData = JsonSerializer.Deserialize<SaveData>(jsonCampaignString);

            _characters = saveData.GetCharacters();
            _enemies = saveData.GetEnemies();

            WriteLineDeluxe($"\nData loaded from \"{filename}\"!");
        }
        catch (FileNotFoundException)
        {
            WriteLineDeluxe("The file was not found.");
        }
    }
}

