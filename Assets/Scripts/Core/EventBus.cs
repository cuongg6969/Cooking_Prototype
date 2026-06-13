using System;
using System.Collections.Generic;

public static class EventBus
{
    static readonly Dictionary<Type, List<Delegate>> _subscribers = new();

    public static void Subscribe<T>(Action<T> handler) where T : struct
    {
        var type = typeof(T);
        if (!_subscribers.ContainsKey(type))
            _subscribers[type] = new List<Delegate>();
        _subscribers[type].Add(handler);
    }

    public static void Unsubscribe<T>(Action<T> handler) where T : struct
    {
        if (_subscribers.TryGetValue(typeof(T), out var list))
            list.Remove(handler);
    }

    public static void Publish<T>(T eventData) where T : struct
    {
        if (!_subscribers.TryGetValue(typeof(T), out var list)) return;

        foreach (var handler in list.ToArray())
            ((Action<T>)handler)?.Invoke(eventData);
    }
}