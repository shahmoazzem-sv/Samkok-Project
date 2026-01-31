public class PlayerAttackState : IState
{
    Player player;
    public PlayerAttackState(Player player)
    {
        this.player = player;
    }

    public void Enter()
    {
        // set animation trigger to attack
    }

    public void Exit()
    {
        // set animation trigger to idle
    }

    public void Update()
    {
        // opponent take damage
        Enemy enemy = player.targetToAttack;
        enemy.TakeDamage(player.hitPoint);
    }
}