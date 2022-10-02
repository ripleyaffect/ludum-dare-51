using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaterCoolerActivityUI : ActivityUI
{
    [SerializeField] private TMP_Text promptText;

    private WaterCoolerTask _task;

    public override void RenderTask(Task task)
    {
        var newTask = (WaterCoolerTask) task;
        _task = newTask;

        promptText.text = $"\"{_task.Prompt}\"";
    }

    public void OnClickHappy()
    {
        _task.ChooseOption(WaterCoolerOptions.Happy);
    }

    public void OnClickSad()
    {
        _task.ChooseOption(WaterCoolerOptions.Sad);
    }
}
