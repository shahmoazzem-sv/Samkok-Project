using UnityEngine;
using UnityTimer;
public class PlayerAttackState : IState
{
    Player player;
    Enemy enemy;
    Timer timer;
    public PlayerAttackState(Player player)
    {
        this.player = player;
    }

    public void Enter()
    {
        enemy = player.targetToAttack;
        timer = Timer.Register(1f, () =>
        {
            if (enemy.life <= 0)
            {
                enemy.ChangeState(EntityState.Die);
                // player.ChangeState(EntityState.Idle);
                timer.Cancel();
            }
            else
            {
                if (player.life > 0)
                    enemy.TakeDamage(player.hitPoint);
            }
        }, isLooped: true);
    }

    public void Exit()
    {
        // set animation trigger to idle
        timer.Cancel();
    }

    public void Update()
    {

    }
}