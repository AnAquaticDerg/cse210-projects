using System.Text.Json.Serialization;
using static DeluxeConsole;
[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(Enemy), "enemy")]
[JsonDerivedType(typeof(Fighter), "fighter")]
[JsonDerivedType(typeof(Caster), "caster")]
[JsonDerivedType(typeof(Ranger), "ranger")]
[JsonDerivedType(typeof(Healer), "healer")]

public class Character
{
    [JsonInclude]
    protected string _name;
    [JsonInclude]
    protected int _maxHealth;
    [JsonInclude]
    protected int _currentHealth;
    [JsonInclude]
    protected int _damage;
    [JsonInclude]
    protected int _dodgeProcChance;
    [JsonInclude]
    protected int _score;
    [JsonInclude]
    private int _scoreToNextLevel;
    [JsonInclude]
    protected int _level;
    protected static Random _random = new Random();

    [JsonConstructor]
    public Character() {}
    public Character(string name)
    {
        _name = name;
        _score = 0;
        _scoreToNextLevel = 10;
        _level = 1;
    }
    
    public virtual int DealDamage()
    {
        if (IsDead())
        {
            Console.WriteLine($"{_name} is too injured to do anything...");
            return 0;
        }
        else
        {
           return _damage;        
        }
    }
    public void TakeDamage(int damageTaken)
    {
        int procAttempt = _random.Next(100) + 1;
        if (procAttempt <= _dodgeProcChance && damageTaken > 0)
        {
            WriteLineDeluxe($"{_name} dodged the attack!");
            return;
        }
        else
        {
            _currentHealth -= damageTaken;

            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
            else if (_currentHealth < 0)
            {
                _currentHealth = 0;
            }
            if (damageTaken > 0)
            {
                WriteLineDeluxe($"{_name} took {damageTaken} damage! They are now on {_currentHealth}/{_maxHealth} HP.");
            }
            else if (damageTaken == 0)
            {
                WriteLineDeluxe($"{_name} is unaffected.");
            }
            else
            {
                WriteLineDeluxe($"{_name} healed {damageTaken * -1} HP! They are now on {_currentHealth}/{_maxHealth} HP.");
            }
        }

        if (_currentHealth <= 0)
        {
            WriteLineDeluxe($"{_name} got hurt and collapsed.");
        }
    }
    
    public string GetName()
    {
        return _name;
    }
    public bool IsDead()
    {
        if (_currentHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ResetHealth()
    {
        _currentHealth = _maxHealth;
    }
    
    public void UpdateLevel(int scoreGained)
    {
        _score += scoreGained;
        
        WriteLineDeluxe();
        while (_score >= _scoreToNextLevel)
        {
            int startingAmount = _score - _scoreToNextLevel;
            _score = startingAmount;
            _scoreToNextLevel += 5 + _level * 3;

            _maxHealth += 3 + _random.Next(4);
            _damage += 1 + _random.Next(3);
            _dodgeProcChance += _random.Next(5) / 2;

            _level++;
            WriteLineDeluxe($"{_name} leveled up! They are now level {_level}!");
        }
    }
    public virtual void DisplayStats()
    {
        if (_currentHealth > 0)
        {        
            WriteLineDeluxe($"Lv {_level} {_name}: {_currentHealth}/{_maxHealth} HP");
        }
        else
        {
            WriteLineDeluxe($"Lv {_level} {_name}: {_currentHealth}/{_maxHealth} HP (DOWN)");
        }
    }
    public void DisplayDetailedStats()
    {
        WriteLineDeluxe($"Lv {_level} {GetType()} {_name}: {_maxHealth} HP | {_damage} ATK | {_dodgeProcChance} DGE | {_scoreToNextLevel - _score} XP to next level.");
    }
}