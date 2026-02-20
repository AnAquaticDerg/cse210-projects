using System.Data;
using System.Text.Json.Serialization;

public class Fighter : Character
{
    [JsonConstructor]
    public Fighter() {}
    public Fighter(string name) : base(name)
    {
        _damage = 6;
        _maxHealth = 20;
        _currentHealth = _maxHealth;
        _dodgeProcChance = 1;
    }

    public override int DealDamage()
    {
        int randomCrit = _damage + _random.Next(_damage + _damage / 2);
        return randomCrit;
    }
}