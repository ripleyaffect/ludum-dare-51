using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : EventListener<ELevelChanged, EPlayerLose, EPlayerWin>
{
    [SerializeField] public LevelData currentLevelData;

    public override void OnEvent(ELevelChanged e)
    {
        currentLevelData = e.NewLevelData;
    }

    public override void OnEvent(EPlayerLose e)
    {
        LoadScene(2);
    }

    public override void OnEvent(EPlayerWin e)
    {
        LoadScene(3);
    }

    private void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
