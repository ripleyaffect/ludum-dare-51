
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class WhiteboardActivity : Activity
{
    [Header("Prompts")]
    [SerializeField] private string[] prompts;

    protected override Task GenerateTask(int taskPoints)
    {
        return new WhiteboardTask()
        {
            points = taskPoints,
            Prompt = GetRandomPrompt(),
        };
    }

    private char[] GetRandomPrompt() => prompts[Random.Range(0, prompts.Length)].ToCharArray();
}
