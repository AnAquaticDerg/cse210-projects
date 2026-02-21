using System.Text.Json.Serialization;
using static DeluxeConsole;
public class Ranger : Character
{
    [JsonConstructor]
    public Ranger() {}
    public Ranger(string name) : base(name)
    {
        _damage = 4;
        _maxHealth = 20;
        _currentHealth = _maxHealth;
        _dodgeProcChance = 40;
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
            int procAttempt = _random.Next(100) + 1;
            if (procAttempt >= 50)
            {
                return _damage;
            }
            else
            {
                WriteLineDeluxe($"{_name} landed a critical shot and dealt twice as much damage!");
                return _damage * 2;
            }
        }
    }
}