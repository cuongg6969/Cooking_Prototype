using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public static class EventBus
{
    private static Dictionary<Type, Delegate> events = new Dictionary<Type, Delegate>();

    public static void Subscribe<T>(Action<T> listener)
    {
        if (events.TryGetValue(typeof(T), out var existing))
        {
            events[typeof(T)] = Delegate.Combine(existing, listener);
        }
        else
        {
            events[typeof(T)] = listener;
        }
    }

    public static void Unsubscribe<T>(Action<T> listener)
    {
        if (events.TryGetValue(typeof(T), out var existing))
        {
            events[typeof(T)] = Delegate.Remove(existing, listener);
        }
    }

    public static void Publish<T>(T eventData)
    {
        if (events.TryGetValue(typeof(T), out var del))
        {
            ((Action<T>)del)?.Invoke(eventData);
        }
    }
}
