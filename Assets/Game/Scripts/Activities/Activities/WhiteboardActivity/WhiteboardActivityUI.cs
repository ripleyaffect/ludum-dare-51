using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WhiteboardActivityUI : ActivityUI
{
    [SerializeField] private TMP_Text[] chars;

    [Header("Colors")]
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color correctColor;

    private WhiteboardTask _task;

    public override void RenderTask(Task task)
    {
        var newTask = (WhiteboardTask) task;

        // Unsubscribe if needed
        if (newTask != _task && _task != null) _task.OnCharacterCorrect -= UpdateChars;

        _task = newTask;

        _task.OnCharacterCorrect += UpdateChars;

        UpdateChars();
    }

    private void UpdateChars()
    {
        for (var i = 0; i < 4; i++)
        {
            chars[i].text = _task.Prompt[i].ToString();
            chars[i].color = _task.CurrentIndex > i ? correctColor : defaultColor;
        }
    }

    public void OnClickA()
    {
        _task.ChooseCharacter('A');
    }

    public void OnClickB()
    {
        _task.ChooseCharacter('B');
    }
}
