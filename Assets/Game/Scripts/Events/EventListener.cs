using UnityEngine;

public abstract class EventListener<
    T1
> : MonoBehaviour,
    IEventListener<T1>
    where T1 : EBase
// T2 : EBase
{
    public abstract void OnEvent(T1 e);

    private void OnEnable() {
        EventManager.Subscribe<T1>(OnEvent);
    }
    private void OnDisable() {
        EventManager.Unsubscribe<T1>(OnEvent);
    }
}

public abstract class EventListener<
    T1,
    T2
> : MonoBehaviour,
    IEventListener<T1, T2>
    where T1 : EBase
    where T2 : EBase
// T2 : EBase
{
    public abstract void OnEvent(T1 e);
    public abstract void OnEvent(T2 e);

    private void OnEnable() {
        EventManager.Subscribe<T1>(OnEvent);
        EventManager.Subscribe<T2>(OnEvent);
    }
    private void OnDisable() {
        EventManager.Unsubscribe<T1>(OnEvent);
        EventManager.Unsubscribe<T2>(OnEvent);
    }
}

public abstract class EventListener<
    T1,
    T2,
    T3
> : MonoBehaviour,
    IEventListener<T1, T2, T3>
    where T1 : EBase
    where T2 : EBase
    where T3 : EBase
// T2 : EBase
{
    public abstract void OnEvent(T1 e);
    public abstract void OnEvent(T2 e);
    public abstract void OnEvent(T3 e);

    private void OnEnable() {
        EventManager.Subscribe<T1>(OnEvent);
        EventManager.Subscribe<T2>(OnEvent);
        EventManager.Subscribe<T3>(OnEvent);
    }
    private void OnDisable() {
        EventManager.Unsubscribe<T1>(OnEvent);
        EventManager.Unsubscribe<T2>(OnEvent);
        EventManager.Unsubscribe<T3>(OnEvent);
    }
}
