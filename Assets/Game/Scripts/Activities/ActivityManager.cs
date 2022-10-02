using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityManager : EventListener<ELevelChanged>
{
    [SerializeField] private List<Activity> activities;

    [Header("Task Generation")]
    [SerializeField] private float taskFrequencySeconds = 10f;
    [SerializeField] private Vector2Int pointsMinMax = new Vector2Int(1, 2);

    private List<Activity> _addableActivities = new List<Activity>();

    private void Start()
    {
        StartCoroutine(TaskEverySeconds());
    }

    public override void OnEvent(ELevelChanged e)
    {
        pointsMinMax.y += 1;
    }

    public void RegisterActivity(Activity activity)
    {
        if (activities.Contains(activity)) return;
        activities.Add(activity);
    }

    public void UnregisterActivity(Activity activity)
    {
        if (!activities.Contains(activity)) return;
        activities.Remove(activity);
    }

    private IEnumerator TaskEverySeconds()
    {
        while (true)
        {
            yield return new WaitForSeconds(taskFrequencySeconds);
            AddTaskToRandomActivity();
        }
    }

    private void AddTaskToRandomActivity()
    {
        _addableActivities.Clear();

        foreach (var activity in activities)
            if (activity.CanAddTask) _addableActivities.Add(activity);

        var addableCount = _addableActivities.Count;

        // No activities can take new tasks
        if (addableCount == 0) return;

        // Add a task to a random activity
        _addableActivities[Random.Range(0, addableCount)].AddTask(GetRandomPoints());
    }

    private int GetRandomPoints() => Random.Range(pointsMinMax.x, pointsMinMax.y);
}
