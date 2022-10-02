using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WaterCoolerOptions
{
    Happy,
    Sad,
}

public class WaterCoolerTask : Task
{
    public string Prompt;
    public WaterCoolerOptions CorrectOption;

    public void ChooseOption(WaterCoolerOptions option)
    {
        if (option == CorrectOption) Complete();
        else Fail();
    }
}
