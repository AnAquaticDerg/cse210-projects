public class Battlefield
{
    private List<Character> _playerCharacters;
    private List<Enemy> _enemies;
    private int _turn;

    public Battlefield(List<Character> characters, List<Enemy> enemies)
    {
        _playerCharacters = characters;
        _enemies = enemies;
        _turn = 0;
    }

    public void PerformTurn() {}
    private void RunPlayerTurn() {}
    public void RunEnemyTurn() {}
    private void LoseBattle() {}
    private void WinBattle() {}
}