using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public static class EventBus<T>
{
    public static Action<T> OnEvent = null;

    public static void Subscribe(Action<T> listener)
    {
        OnEvent += listener;
    }
    public static void Unsubscribe(Action<T> listener)
    {
        OnEvent -= listener;
    }
    public static void Raise(T payload)
    {
        OnEvent?.Invoke(payload);
    }
}