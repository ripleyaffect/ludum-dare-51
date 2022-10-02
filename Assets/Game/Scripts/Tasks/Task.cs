using System;
using UnityEngine;

[Serializable]
public abstract class Task
{
    public Activity activity;
    public int points;

    public Action<Task> OnCompleted;
    public Action<Task> OnFailed;

    public void Complete()
    {
        OnCompleted?.Invoke(this);

        new ETaskCompleted()
        {
            Task = this,
        }.Emit();
    }

    public void Fail()
    {
        OnFailed?.Invoke(this);

        new ETaskFailed()
        {
            Task = this,
        }.Emit();
    }
}
