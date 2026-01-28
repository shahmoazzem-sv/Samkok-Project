using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;


public enum BattleState
{
    None,
    BattleAtttacking,
    Idle
}

public class BattleManager : MonoBehaviour
{

    List<Player> players;
    List<Enemy> enemies;

    public BattleState currentState;
    public StateMachine battleStateMachine;

    bool isPlayerAttacking;


    public Action onIdleWaitFinished;



    void Start()
    {
        players = new List<Player>();
        enemies = new List<Enemy>();

        battleStateMachine = new StateMachine();
        currentState = BattleState.None;
    }




    public void ChangeState(BattleState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }


        switch (currentState)
        {
            case BattleState.None:
                break;
            case BattleState.Idle:
                battleStateMachine.SetState(new BattleIdleState(this));
                break;
            case BattleState.BattleAtttacking:
                battleStateMachine.SetState(new BattleAttackingState(this, players, enemies));
                break;
            default:
                break;
        }
    }

    void Update()
    {
        battleStateMachine.Update();
    }


    // helping fuctiosn


    Enemy ChoseEnemy()
    {
        int randomIndex = Random.Range(0, enemies.Count);
        return enemies[randomIndex];
    }

    Player ChosePlayer()
    {
        int randomIndex = Random.Range(0, enemies.Count);
        return players[randomIndex];
    }

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    IEnumerator WaitInIdle()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Now Attack will Happend");
        onIdleWaitFinished?.Invoke();
    }

    public void WaitForSec()
    {
        StartCoroutine(WaitInIdle());
    }




}
