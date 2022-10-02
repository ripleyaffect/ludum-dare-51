using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float secondsBetweenFrames = 0.25f;

    [Header("Frames")]
    [SerializeField] private Sprite standSprite;
    [SerializeField] private Sprite runSprite;

    private bool _isRunning;
    private bool _coroutineActive;
    private EPlaySfx _sfxEvent;

    public void Awake()
    {
        _sfxEvent = new EPlaySfx
        {
            Type = SfxTypes.Move,
        };
    }

    public void SetFlipX(bool flipX)
    {
        spriteRenderer.flipX = flipX;
    }

    public void Run()
    {
        // Already running
        if (_isRunning) return;
        _isRunning = true;

        if (_coroutineActive) return;

        StartCoroutine(RunAnimation());
    }

    public void Stand()
    {
        _isRunning = false;
    }

    private IEnumerator RunAnimation()
    {
        _coroutineActive = true;

        while (_isRunning)
        {
            spriteRenderer.sprite = runSprite;
            _sfxEvent.Emit();
            yield return new WaitForSeconds(secondsBetweenFrames);
            spriteRenderer.sprite = standSprite;
            yield return new WaitForSeconds(secondsBetweenFrames);
        }

        _coroutineActive = false;
    }
}
