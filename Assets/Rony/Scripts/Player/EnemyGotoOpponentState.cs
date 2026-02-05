using UnityEngine;
public class EnemyGotoOpponentState : IState
{
    Enemy enemy;
    Player player;
    public EnemyGotoOpponentState(Enemy enemy)
    {
        this.enemy = enemy;
    }
    public void Enter()
    {
        // Find the position of the target
        player = enemy.targetToAttack;
        if (player == null)
        {
            enemy.ChangeState(EntityState.Idle);
            return;
        }

    }

    public void Exit()
    {

    }

    public void Update()
    {
        float distance = Vector3.Distance(enemy.transform.position, player.transform.position);
        if (distance < 2f)
        {
            enemy.ChangeState(EntityState.Attack);
        }
        else
        {
            Debug.Log("enemy" + enemy.transform);
            enemy.MoveSelfFromTo(enemy.transform, player.transform);
        }
    }
}