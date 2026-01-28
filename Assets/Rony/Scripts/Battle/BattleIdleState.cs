
using UnityEngine;

public class BattleIdleState : IState
{
    BattleManager battleManager;
    public BattleIdleState(BattleManager battleManager)
    {
        this.battleManager = battleManager;
    }
    public void Enter()
    {
        Debug.Log("WE are in battle mode in idle state");
        battleManager.onIdleWaitFinished += FinishTheIdle;
        battleManager.WaitForSec();
    }

    public void Exit()
    {

    }

    void FinishTheIdle()
    {
        battleManager.ChangeState(BattleState.BattleAtttacking);
    }


    public void Update()
    {
        Debug.Log("Battle is going on .dhoom dhoom");
    }


}
