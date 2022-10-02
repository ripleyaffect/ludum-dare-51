using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteboardTask : Task
{
    public char[] Prompt;
    public int CurrentIndex;

    public Action OnCharacterCorrect;

    public void ChooseCharacter(char character)
    {
        if (character != Prompt[CurrentIndex])
        {
            Fail();
            return;
        }

        CurrentIndex += 1;

        OnCharacterCorrect?.Invoke();

        if (CurrentIndex == Prompt.Length) Complete();
    }
}
