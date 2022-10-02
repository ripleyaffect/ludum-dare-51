using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    private static readonly Dictionary<Type, Action<EBase>> ActionByType;
    private static readonly Dictionary<Delegate, Action<EBase>> ActionByDelegate;

    static EventManager()
    {
        ActionByType = new Dictionary<Type, Action<EBase>>();
        ActionByDelegate = new Dictionary<Delegate, Action<EBase>>();
    }

    public static void Subscribe<T>(Action<T> listener) where T : EBase
    {
        // Already subscribed
        if (ActionByDelegate.ContainsKey(listener)) return;

        void NewAction(EBase e) => listener((T) e);

        ActionByDelegate[listener] = NewAction;

        if (ActionByType.TryGetValue(typeof(T), out Action<EBase> internalAction))
            ActionByType[typeof(T)] += NewAction;
        else
            ActionByType[typeof(T)] = NewAction;
    }

    public static void Unsubscribe<T>(Action<T> listener) where T : EBase
    {
        // Not subscribed
        if (!ActionByDelegate.TryGetValue(listener, out var action)) return;

        if (ActionByType.TryGetValue(typeof(T), out var tempAction))
        {
            tempAction -= action;
            if (tempAction == null)
                ActionByType.Remove(typeof(T));
            else
                ActionByType[typeof(T)] = tempAction;
        }

        ActionByDelegate.Remove(listener);
    }

    public static void Emit(EBase e)
    {
        if (ActionByType.TryGetValue(e.GetType(), out var action))
            action.Invoke(e);
    }

    public static void Clear()
    {
        ActionByType.Clear();
        ActionByDelegate.Clear();
    }
}
