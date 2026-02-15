using System.Runtime.CompilerServices;

public class Enemy : Character
{
    private int _scoreValue;

    public Enemy(string name, int maxHealth, int damage, int scoreValue) : base(name, maxHealth, damage)
    {
        _scoreValue = scoreValue;
    }

    public int GetScoreIfDead()
    {
        if (_currentHealth <= 0)
        {
            return _scoreValue;
        }
        else
        {
            return 0;
        }
    }
}