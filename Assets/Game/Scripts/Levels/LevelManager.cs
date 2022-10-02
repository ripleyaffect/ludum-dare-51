using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : EventListener<ETaskCompleted, ETaskFailed, EPlayerReviewRequested>
{
    [Header("Levels")]
    [SerializeField] private List<LevelData> levels;
    [SerializeField] private int currentLevelIndex = 0;

    [Header("Points")]
    [SerializeField] private int basePointsToNextLevel = 3;
    [SerializeField] private int extraPointsPerLevel = 1;
    [SerializeField] public int pointsToNextLevel;
    [SerializeField] public int currentPoints;

    public LevelData CurrentLevelData => levels[currentLevelIndex];

    public Action OnPointsChanged;
    public Action OnLevelChanged;

    private ELevelChanged _levelChangedEvent;
    private EPlaySfx _sfxEvent;

    private void Awake()
    {
        pointsToNextLevel = basePointsToNextLevel;
        _levelChangedEvent = new ELevelChanged();
        _sfxEvent = new EPlaySfx();
    }

    public override void OnEvent(ETaskFailed e) => EmitSfx(SfxTypes.TaskFailed);
    public override void OnEvent(ETaskCompleted e) => GivePoints(e.Task.points);

    public override void OnEvent(EPlayerReviewRequested e) => Review();

    private void GivePoints(int amount)
    {
        currentPoints += amount;

        OnPointsChanged?.Invoke();

        EmitSfx(SfxTypes.TaskCompleted);
    }

    private void Review()
    {
        if (currentPoints < pointsToNextLevel) Fire();
        else Promote();
    }

    private void Fire()
    {
        new EPlayerLose().Emit();
    }

    private void Promote()
    {
        currentLevelIndex += 1;

        // Victory!
        if (currentLevelIndex == levels.Count)
        {
            new EPlayerWin().Emit();
            return;
        }

        // Reset points and set next points needed
        currentPoints = 0;
        pointsToNextLevel = basePointsToNextLevel + (currentLevelIndex * extraPointsPerLevel);

        OnLevelChanged?.Invoke();

        _levelChangedEvent.NewLevelData = levels[currentLevelIndex];
        _levelChangedEvent.Emit();

        EmitSfx(SfxTypes.Promoted);
    }

    private void EmitSfx(SfxTypes sfxType)
    {
        _sfxEvent.Type = sfxType;
        _sfxEvent.Emit();
    }
}
