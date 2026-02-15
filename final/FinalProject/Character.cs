public class Character
{
    protected string _name;
    private int _maxHealth;
    protected int _currentHealth;
    protected int _damage;
    protected int _score;
    private int _scoreToNextLevel;
    private int _level;

    public Character(string name, int maxHealth, int damage)
    {
        _name = name;
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
        _damage = damage;
        _score = 0;
        _scoreToNextLevel = 100;
        _level = 0;
    }
    
    public virtual int DealDamage()
    {
        return _damage;
    }
    public virtual void TakeDamage(int damageTaken)
    {
        _currentHealth -= damageTaken;
        if (_currentHealth <= 0)
        {
            Console.WriteLine($"{_name} got hurt and collapsed.");
        }
    }
    public void UpdateLevel(int scoreGained)
    {
        _score += scoreGained;
        
        while (_score >= _scoreToNextLevel)
        {
            int startingAmount = _score - _scoreToNextLevel;
            _score = startingAmount;
            _scoreToNextLevel = _scoreToNextLevel + _level * 50;

            _level++;
            Console.WriteLine($"{_name} leveled up! They are now level {_level}!");
        }
    }
    public void DisplayStats()
    {
        Console.WriteLine($"Lv {_level} {_name}: {_currentHealth}/{_maxHealth}");
    }

}