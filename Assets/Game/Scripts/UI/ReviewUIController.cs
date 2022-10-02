using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReviewUIController : EventListener<ELevelChanged>
{
    [SerializeField] private LevelManager manager;
    [SerializeField] private Slider slider;
    [SerializeField] private float secondsBetweenReviews = 10;

    private EPlayerReviewRequested _reviewRequestedEvent;
    private float _secondsUntilReview;

    private void Awake()
    {
        _reviewRequestedEvent = new EPlayerReviewRequested();

        _secondsUntilReview = secondsBetweenReviews;
        slider.maxValue = secondsBetweenReviews;

        manager.OnLevelChanged += ResetTimer;

        UpdateTimeUntilReview();
    }

    private void Update()
    {
        if (_secondsUntilReview <= 0) return;

        _secondsUntilReview -= Time.deltaTime;
        UpdateTimeUntilReview();

        if (_secondsUntilReview > 0f) return;

        _reviewRequestedEvent.Emit();
    }

    public override void OnEvent(ELevelChanged e)
    {
        ResetTimer();
    }

    private void ResetTimer()
    {
        _secondsUntilReview = secondsBetweenReviews;
    }

    private void UpdateTimeUntilReview()
    {
        slider.value = _secondsUntilReview;
    }

}
