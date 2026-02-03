using UnityEngine;
using UnityTimer;
public class EnemyAttackState : IState
{
    Enemy enemy;
    Player player;
    Timer timer;
    public EnemyAttackState(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        player = enemy.targetToAttack;
        timer = Timer.Register(1f, () =>
        {
            if (player.life <= 0)
            {
                player.ChangeState(EntityState.Die);
                enemy.ChangeState(EntityState.Idle);
                timer.Cancel();
            }
            else
            {
                if (enemy.life > 0)
                    player.TakeDamage(enemy.hitPoint);
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