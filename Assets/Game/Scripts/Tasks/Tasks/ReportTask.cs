using System;

public class ReportTask : Task
{
    public int MaxClicks = 1;
    public int Clicks;

    public string Prompt;
    public bool CorrectOption;

    public void ChooseOption(bool option)
    {
        if (option == CorrectOption) Complete();
        else Fail();
    }

    public Action OnUpdated;

    public void AddClicks(int amount)
    {
        Clicks += amount;

        OnUpdated?.Invoke();

        if (Clicks >= MaxClicks) Complete();
    }
}
