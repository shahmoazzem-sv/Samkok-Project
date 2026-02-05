
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
        // Wait for the loading completion and battle start
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
        // Debug.Log("Currently the Battle is on IDLE state");
    }


}
