using System.Text.Json.Serialization;

public class Healer : Character
{
    [JsonConstructor]
    public Healer() {}
    public Healer(string name) : base(name)
    {
        _damage = 8;
        _maxHealth = 16;
        _currentHealth = _maxHealth;
        _dodgeProcChance = 1;
    }

    public override int DealDamage()
    {
        Console.WriteLine($"{_name} healed {_damage} HP!");
        return -_damage;
    }
}