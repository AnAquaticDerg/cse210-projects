using System.Text.Json.Serialization;
using static DeluxeConsole;
public class Caster : Character
{
    [JsonConstructor]
    public Caster() {}
    public Caster(string name) : base(name)
    {
        _damage = 8;
        _maxHealth = 16;
        _currentHealth = _maxHealth;
        _dodgeProcChance = 80;
    }

    
}