using System.Formats.Asn1;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using static DeluxeConsole;


public class Battlefield
{
    private List<Character> _playerCharacters;
    private List<Enemy> _enemies;
    private int _turn;
    private string _status;
    private int _totalEncounterScore;
    private Random _random = new Random();

    public Battlefield(List<Character> characters, List<Enemy> enemies)
    {
        _playerCharacters = characters;
        _enemies = enemies;
        _status = "fighting";
        _turn = 0;
    }

    public void Battle()
    {
        if (!TeamsExist())
        {
            return;
        }
        while (_status == "fighting")
        {
            Console.Clear();
            _turn++;
            WriteLineDeluxe($"\nTurn {_turn}.");

            RunPlayerTurn();
            DisplaySpinner(2);
            CheckEnemies();

            if (_status != "won")
            {
                RunEnemyTurn();
                DisplaySpinner(2);
                CheckPlayers();
            }
        }
    }
    private bool TeamsExist()
    {
        if (_playerCharacters.Count() <= 0 && _enemies.Count() <= 0)
        {
            WriteLineDeluxe("\nBoth teams are empty. Come back after you've made some teammates and enemies.");
            DisplaySpinner(2);
            return false;
        }
        else if (_playerCharacters.Count() <= 0)
        {
            WriteLineDeluxe("\nYou don't have any characters on your team. Come back after you've made some.");
            DisplaySpinner(2);
            return false;
        }
        else if (_enemies.Count() <= 0)
        {
            WriteLineDeluxe("\nYou don't have any enemies to fight. Come back after you've made some.");
            DisplaySpinner(2);
            return false;
        }
        else
        {
            return true;
        }
    }
    
    private void RunPlayerTurn()
    {
        DisplayCharacters();

        int actorIndex = -1;
        try
        {
            do
            {
                WriteLineDeluxe("\nSelect a character.");
                actorIndex = int.Parse(Console.ReadLine()) - 1;
            } while (actorIndex > _playerCharacters.Count() - 1 || actorIndex < 0);
        }
        catch (System.FormatException)
        {
            RunPlayerTurn();
        }
        Character actor = _playerCharacters[actorIndex];

        if (actor is Healer)
        {
            DisplayCharacters();
            
            int targetIndex = -1;
            do
            {
                WriteLineDeluxe("\nSelect a target.");
                targetIndex = int.Parse(Console.ReadLine()) - 1;
            } while (targetIndex > _playerCharacters.Count() - 1 || targetIndex < 0);

            Character target = _playerCharacters[targetIndex];

            WriteLineDeluxe($"\n{actor.GetName()} healed {target.GetName()}!");
            target.TakeDamage(actor.DealDamage());
        }
        else
        {    
            DisplayEnemies();

            int targetIndex = -1;
            do
            {
                WriteLineDeluxe("\nSelect a target.");
                targetIndex = int.Parse(Console.ReadLine()) - 1;
            } while (targetIndex > -_enemies.Count() - 1 || targetIndex < 0);

            Enemy target = _enemies[targetIndex];

            WriteLineDeluxe($"\n{actor.GetName()} attacked {target.GetName()}!");
            target.TakeDamage(actor.DealDamage());
        }
    }
    private void DisplayEnemies()
    {
        WriteLineDeluxe("\nEnemy team:");
        int i = 0;
        foreach (Enemy enemy in _enemies)
        {
            if(!enemy.IsDead())
            {    
                i++;
                Console.Write($"   {i}. ");
                enemy.DisplayStats();
            }
        }
    }
    private void DisplayCharacters()
    {
        WriteLineDeluxe("\nYour team:");
        int i = 0;
        foreach (Character character in _playerCharacters)
        {
            i++;
            Console.Write($"   {i}. ");
            character.DisplayStats();
        }
    }
    private void RunEnemyTurn()
    {
        int actorIndex = _random.Next(_enemies.Count());
        Enemy actor = _enemies[actorIndex];

        int targetIndex = _random.Next(_playerCharacters.Count());
        Character target = _playerCharacters[targetIndex];

        WriteLineDeluxe($"\n{actor.GetName()} attacked {target.GetName()}!");
        target.TakeDamage(actor.DealDamage());
    }
    
    private void CheckEnemies()
    {
        for (int i = _enemies.Count() - 1; i >= 0; i--)
        {
            if (_enemies[i].IsDead())
            {
                _totalEncounterScore += _enemies[i].GetScore() / _playerCharacters.Count();
                _enemies.RemoveAt(i);
            }
        }
        if (_enemies.Count() > 0)
        {
            return;
        }
        WinBattle();
    }
    private void CheckPlayers()
    {
        foreach (Character character in _playerCharacters)
        {
            if (!character.IsDead())
            {
                return;
            }
        }
        LoseBattle();
    }
    
    private void LoseBattle()
    {
        string willPersist = "";
        while (willPersist != "yes" && willPersist != "no")
        {
            Console.Clear();
            WriteLineDeluxe("It appears you have met an end. Will you persist?", 0);
            willPersist = Console.ReadLine().ToLower();

            if (willPersist == "yes")
            {
                WriteLineDeluxe("Then fate is in your hands.", 0);
                _turn = 0;

                ResetTeams();

                DisplaySpinner();
            }
            else if (willPersist == "no")
            {
                WriteLineDeluxe("Then the world was covered in darkness.", 0);
                _status = "lost";
                
                ResetTeams();
                
                DisplaySpinner();
            }
        }
    }
    private void WinBattle()
    {
        WriteLineDeluxe("\nCongraduations! You won!");
        _status = "won";

        WriteLineDeluxe($"Each character earned {_totalEncounterScore} XP!");

        foreach (Character character in _playerCharacters)
        {
            character.UpdateLevel(_totalEncounterScore);
        }
        DisplaySpinner(5);

        ResetTeams();
    }
    private void ResetTeams()
    {
        foreach (Character character in _playerCharacters)
        {
            character.ResetHealth();
        }
        foreach (Enemy enemy in _enemies)
        {
            enemy.ResetHealth();
        }
    }
}