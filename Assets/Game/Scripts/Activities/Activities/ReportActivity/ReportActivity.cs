
using System.Collections.Generic;
using UnityEngine;

public class ReportActivity : Activity
{
    [Header("Prompts")]
    [SerializeField] private string[] falsePrompts;
    [SerializeField] private string[] truePrompts;

    protected override Task GenerateTask(int taskPoints)
    {
        var correctOption = Random.Range(0f, 1f) >= 0.5f;

        return new ReportTask
        {
            points = taskPoints,
            CorrectOption = correctOption,
            Prompt = GetOptionPrompt(correctOption),
        };
    }

    private string GetOptionPrompt(bool option) => GetRandomPrompt(
        option ? truePrompts : falsePrompts
    );

    private static string GetRandomPrompt(IReadOnlyList<string> prompts) => prompts[Random.Range(0, prompts.Count)];
}
