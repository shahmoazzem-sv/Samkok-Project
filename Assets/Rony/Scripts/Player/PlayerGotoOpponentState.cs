using System.Linq.Expressions;
using UnityEngine;

public class PlayerGotoOpponentState : IState
{

    Player player;
    Enemy enemy;

    // Threshold to consider "reached" (e.g., 0.5 units away)
    // private float stopDistance = 2f;


    public PlayerGotoOpponentState(Player player)
    {
        this.player = player;
    }


    public void Enter()
    {
        enemy = player.targetToAttack;
        if (enemy == null)
        {
            player.ChangeState(EntityState.Idle);
            return;
        }

        // Play walking/running animation here if needed
        // player.anim.Play("Walk");
    }

    public void Exit()
    {
    }




    public void Update()
    {

        // 1. Check Distance
        float distance = Vector2.Distance(player.transform.position, enemy.transform.position);
        if (distance < 2f)
        {
            // 2. We have reached the target -> Raise the Event
            player.ChangeState(EntityState.Attack);
        }
        else
        {
            player.MoveSelfFromTo(player.transform, enemy.transform);
        }

    }




}
