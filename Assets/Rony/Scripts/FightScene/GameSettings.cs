using System;

public enum EntityState
{
    Idle,
    GotoOpponent,
    Attack,
    Die
}
public enum PlayerType
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