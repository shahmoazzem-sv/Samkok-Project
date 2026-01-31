using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;


public enum BattleState
{
    None,
    BattleAtttacking,
    Idle,
    Finish
}

public class BattleManager : MonoBehaviour
{

    public List<Player> players { get; private set; }
    public List<Enemy> enemies { get; private set; }

    public BattleState currentState;
    public StateMachine battleStateMachine;


    public Action onIdleWaitFinished;

    void Awake()
    {
        players = new List<Player>();
        enemies = new List<Enemy>();
        battleStateMachine = new StateMachine();
    }


    void Start()
    {
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
                battleStateMachine.SetState(new BattleAttackingState(this));
                break;
            default:
                break;
        }
    }

    void Update()
    {
        battleStateMachine.Update();
    }

    public void AddPlayer(Player player)
    {
        if (players == null) Debug.Log("Not Set");
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
