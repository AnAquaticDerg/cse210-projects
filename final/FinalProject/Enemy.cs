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
        _scoreValue = enemyLevel * 5 + _random.Next(10);
        _maxHealth = 20 + enemyLevel * 5 + _random.Next(5);
        _currentHealth = _maxHealth;
        _damage = 4 + enemyLevel * 2;
        _dodgeProcChance = 0 + enemyLevel / 5;
    }

    public int GetScore()
    {
        return _scoreValue;
    }
    public override int DealDamage()
    {
        int randomDamage = 2 +_random.Next(_damage);
        return randomDamage;
    }

}