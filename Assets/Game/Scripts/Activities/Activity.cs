using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Activity : MonoBehaviour
{
    [SerializeField] public ActivityManager activityManager;
    [SerializeField] private int maxTasks = 1;
    [SerializeField] public float cooldownSeconds = 2;

    [SerializeField] public List<Task> Tasks = new List<Task>();
    [SerializeField] public int currentTaskCount;

    public Action OnTasksUpdated;

    public int TaskCount => Tasks.Count;
    public bool HasTasks => TaskCount > 0;
    public bool CanAddTask => !_inCooldown && TaskCount < maxTasks;
    public Task CurrentTask => HasTasks ? Tasks[0] : null;

    private bool _inCooldown;

    public void AddTask(int taskPoints = 1)
    {
        if (!CanAddTask) return;
        AddTask(GenerateTask(taskPoints));
    }

    protected abstract Task GenerateTask(int taskPoints);

    private void AddTask(Task task)
    {
        if (Tasks.Contains(task)) return;

        // Subscribe to task events
        task.OnCompleted += RemoveTask;
        task.OnFailed += RemoveTask;

        Tasks.Add(task);

        currentTaskCount = Tasks.Count;

        OnTasksUpdated?.Invoke();
    }

    private void RemoveTask(Task task)
    {
        if (!Tasks.Contains(task)) return;

        task.OnCompleted -= RemoveTask;
        task.OnFailed -= RemoveTask;

        Tasks.Remove(task);
        _inCooldown = true;

        currentTaskCount = Tasks.Count;

        OnTasksUpdated?.Invoke();

        StartCoroutine(StartCooldown());
    }

    private IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(cooldownSeconds);
        _inCooldown = false;
    }

    private void OnEnable()
    {
        activityManager.RegisterActivity(this);
    }

    private void OnDisable()
    {
        activityManager.UnregisterActivity(this);
    }
}
