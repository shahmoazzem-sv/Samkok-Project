using System;
public enum GameState
{
    Start,
    Fight,
    End
}

public enum LifeCycle
{
    Idle,
    Attack,
    TakeDamage,
    Die
}
public enum PlayerMove
{
    Melee,
    Projectile
}
public static class EventBus
{
    private static Action<object> action;

    public static void Subscribe(Action<object> action)
    {
        EventBus.action += action;
    }
    public static void Unsubscribe(Action<object> action)
    {
        EventBus.action -= action;
    }
    public static void Publish(object message)
    {
        action?.Invoke(message);
    }
}