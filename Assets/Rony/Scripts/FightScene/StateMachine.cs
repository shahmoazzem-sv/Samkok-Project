public interface IState
{
    public void Enter();
    public void Exit();
    public void Update();
}


public class StateMachine
{
    public IState currentState;

    public void SetState(IState newState)
    {
        if (currentState != null) currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
    public void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
    }
}