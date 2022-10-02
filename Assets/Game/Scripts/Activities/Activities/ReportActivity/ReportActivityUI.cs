using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReportActivityUI : ActivityUI
{
    [SerializeField] private TMP_Text promptText;

    private ReportTask _task;

    public override void RenderTask(Task task)
    {
        var newTask = (ReportTask) task;
        _task = newTask;

        promptText.text = _task.Prompt;
    }

    public void OnClickTrue()
    {
        _task.ChooseOption(true);
    }

    public void OnClickFalse()
    {
        _task.ChooseOption(false);
    }
}
