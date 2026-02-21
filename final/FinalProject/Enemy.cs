using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

public class Enemy : Character
{
    [JsonInclude]
    private int _scoreValue;
    [JsonInclude]
    private int _enemyLevel;

    [JsonConstructor]
    public Enemy() {}
    public Enemy(string name, int enemyLevel) : base(name)
    {
        _level = enemyLevel;
        _scoreValue = enemyLevel * 10 + _random.Next(10);
        _maxHealth = 20 + enemyLevel * 7 + _random.Next(5);
        _currentHealth = _maxHealth;
        _damage = 4 + enemyLevel * 3;
        _dodgeProcChance = enemyLevel / 5;
    }

    public int GetScore()
    {
        return _scoreValue;
    }
    public override int DealDamage()
    {
        int randomDamage = _level +_random.Next(_damage - _level);
        return randomDamage;
    }

}