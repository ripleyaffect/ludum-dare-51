using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SfxManager : EventListener<EPlaySfx>
{
    [SerializeField] private AudioSource audioSource;

    [Header("Sfx Clips")]
    [SerializeField] private AudioClip moveSfx;
    [SerializeField] private AudioClip taskAddedSfx;
    [SerializeField] private AudioClip reportActivitySfx;
    [SerializeField] private AudioClip waterCoolerActivitySfx;
    [SerializeField] private AudioClip whiteboardActivitySfx;
    [SerializeField] private AudioClip taskCompletedSfx;
    [SerializeField] private AudioClip taskFailedSfx;
    [SerializeField] private AudioClip promotedSfx;

    private void Awake()
    {
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
    }

    public override void OnEvent(EPlaySfx e)
    {
        switch (e.Type)
        {
            case SfxTypes.Move:
                Play(moveSfx);
                break;
            case SfxTypes.TaskAdded:
                Play(taskAddedSfx);
                break;
            case SfxTypes.ReportActivity:
                Play(reportActivitySfx);
                break;
            case SfxTypes.WaterCoolerActivity:
                Play(waterCoolerActivitySfx);
                break;
            case SfxTypes.WhiteboardActivity:
                Play(whiteboardActivitySfx);
                break;
            case SfxTypes.TaskCompleted:
                Play(taskCompletedSfx);
                break;
            case SfxTypes.TaskFailed:
                Play(taskFailedSfx);
                break;
            case SfxTypes.Promoted:
                Play(promotedSfx);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void Play(AudioClip clip, float volumeScale = 1f)
    {
        audioSource.PlayOneShot(clip, volumeScale);
    }
}
