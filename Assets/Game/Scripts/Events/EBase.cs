using System;

public abstract class EBase
{
    public static void Subscribe<T>(IEventListener<T> listener) where T : EBase => EventManager.Subscribe<T>(listener.OnEvent);
    public static void Subscribe<T>(Action<T> action) where T : EBase => EventManager.Subscribe(action);

    public static void Unsubscribe<T>(IEventListener<T> listener) where T : EBase => EventManager.Unsubscribe<T>(listener.OnEvent);
    public static void Unsubscribe<T>(Action<T> action) where T : EBase => EventManager.Unsubscribe(action);

    public void Emit() => EventManager.Emit(this);
}
