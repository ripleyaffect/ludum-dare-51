public interface IEventListener<in T> where T : EBase
{
    public void OnEvent(T e);

    private void OnEnable()
    {
        throw new System.NotImplementedException();
    }

    private void OnDisable()
    {
        throw new System.NotImplementedException();
    }
}

public interface IEventListener<in T1, in T2>
    where T1 : EBase
    where T2 : EBase
{
    public void OnEvent(T1 e);
    public void OnEvent(T2 e);
}

public interface IEventListener<in T1, in T2, in T3>
    where T1 : EBase
    where T2 : EBase
    where T3 : EBase
{
    public void OnEvent(T1 e);
    public void OnEvent(T2 e);
    public void OnEvent(T3 e);
}
