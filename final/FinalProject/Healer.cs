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
        if (IsDead())
        {
            Console.WriteLine($"{_name} is too injured to do anything...");
            return 0;
        }
        else
        {
            return -_damage;
        }
    }
}