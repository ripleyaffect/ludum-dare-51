using System;
using UnityEngine;

public class ActivityUIController : EventListener<EActivityZoneEntered, EActivityZoneExited>
{
    [SerializeField] protected Activity activity;
    [SerializeField] protected ActivityUI ui;
    [SerializeField] protected ActivityTasksIndicator indicator;

    private bool _isActive;

    private void Awake()
    {
        activity.OnTasksUpdated += OnActivityTasksUpdated;
    }

    public void OnActivityTasksUpdated()
    {
        UpdateIndicator();
        UpdateActivityUI();
    }

    public override void OnEvent(EActivityZoneEntered e)
    {
        if (e.Activity != activity) return;

        _isActive = true;

        UpdateActivityUI();
    }

    public override void OnEvent(EActivityZoneExited e)
    {
        if (e.Activity != activity) return;

        _isActive = false;

        UpdateActivityUI();
    }

    private void UpdateIndicator()
    {
        var hasTasks = activity.HasTasks;

        // Update the point value on the indicator
        if (hasTasks) indicator.SetTaskPoints(activity.CurrentTask.points);

        indicator.gameObject.SetActive(hasTasks);
    }

    private void UpdateActivityUI()
    {
        if (!_isActive || !activity.HasTasks)
        {
            // TODO Render no tasks ui?
            ui.gameObject.SetActive(false);
            return;
        }

        ui.gameObject.SetActive(true);
        ui.RenderTask(activity.CurrentTask);
    }
}
