public class Healer : Character
{
    public Healer(string name, int maxHealth, int damage) : base(name, maxHealth, damage) {}

    public override int DealDamage()
    {
        return _damage / -2;
    }
}