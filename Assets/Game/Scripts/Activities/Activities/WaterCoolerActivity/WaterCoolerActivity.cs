
using UnityEngine;

public class WaterCoolerActivity : Activity
{
    [Header("Prompts")]
    [SerializeField] private string[] sadPrompts;
    [SerializeField] private string[] happyPrompts;

    protected override Task GenerateTask(int taskPoints = 1)
    {
        var correctOption = Random.Range(0f, 1f) < 0.5f
            ? WaterCoolerOptions.Sad
            : WaterCoolerOptions.Happy;

        return new WaterCoolerTask()
        {
            points = taskPoints,
            CorrectOption = correctOption,
            Prompt = GetOptionPrompt(correctOption),
        };
    }

    private string GetOptionPrompt(WaterCoolerOptions option) => GetRandomPrompt(
        option == WaterCoolerOptions.Sad ? sadPrompts : happyPrompts
    );

    private string GetRandomPrompt(string[] prompts) => prompts[Random.Range(0, prompts.Length)];
}
