using System.Linq.Expressions;
using UnityEngine;

public class PlayerGotoOpponentState : IState
{

    Player player;
    private Transform targetTransform;

    // Threshold to consider "reached" (e.g., 0.5 units away)
    private float stopDistance = 2f;


    public PlayerGotoOpponentState(Player player)
    {
        this.player = player;
    }


    public void Enter()
    {
        if (player.targetToAttack == null)
        {
            player.ChangeState(EntityState.Idle);
            return;
        }
        targetTransform = player.targetToAttack.transform;

        // Play walking/running animation here if needed
        // player.anim.Play("Walk");
    }

    public void Exit()
    {
    }




    public void Update()
    {
        // Safety check in case target is destroyed mid-chase
        if (targetTransform == null) return;

        // 1. Check Distance
        float distance = Vector2.Distance(player.transform.position, targetTransform.position);

        if (distance <= stopDistance)
        {
            // 2. We have reached the target -> Raise the Event
            player.ChangeState(EntityState.Attack);
        }
        else
        {
            // 3. Keep Moving
            player.MoveSelfFromTo(player.transform, targetTransform);
        }

    }




}
