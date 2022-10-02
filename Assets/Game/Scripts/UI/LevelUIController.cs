using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIController : MonoBehaviour
{
    [SerializeField] private LevelManager manager;

    [SerializeField] private Slider slider;
    [SerializeField] private Image sliderFillImage;
    [SerializeField] private TMP_Text titleText;

    [Header("Colors")]
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color promotingColor;

    private void Awake()
    {
        manager.OnPointsChanged += UpdatePoints;
        manager.OnLevelChanged += UpdateAll;

        UpdateAll();
    }

    private void UpdateAll()
    {
        UpdatePoints();
        UpdateTitle();
    }

    private void UpdatePoints()
    {
        slider.maxValue = manager.pointsToNextLevel;
        slider.value = manager.currentPoints;

        // Change the color of the bar when getting promoted
        sliderFillImage.color = manager.currentPoints < manager.pointsToNextLevel
            ? defaultColor
            : promotingColor;
    }

    private void UpdateTitle()
    {
        titleText.text = manager.CurrentLevelData.title;
    }
}
