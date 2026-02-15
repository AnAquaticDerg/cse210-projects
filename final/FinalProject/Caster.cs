public class Caster : Character
{
    Random _random = new Random();

    public Caster(string name, int maxHealth, int damage) : base(name, maxHealth, damage) {}

    public override void TakeDamage(int damageTaken)
    {
        int procAttempt = _random.Next(100) + 1;
        if (procAttempt >= 66)
        {
            return;
        }
        else
        {
            _currentHealth -= damageTaken;
        }
    }
}