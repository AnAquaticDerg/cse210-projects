public class Ranger : Character
{
    Random _random = new Random();

    public Ranger(string name, int maxHealth, int damage) : base(name, maxHealth, damage) {}

    public override int DealDamage()
    {
        int procAttempt = _random.Next(100) + 1;
        if (procAttempt >= 33)
        {
            return _damage;
        }
        else
        {
            return _damage * 2;
        }
    }
    public override void TakeDamage(int damageTaken)
    {
       int procAttempt = _random.Next(100) + 1;
        if (procAttempt >= 33)
        {
            _currentHealth -= damageTaken;
        }
        else
        {
            return;
        } 
    }
}