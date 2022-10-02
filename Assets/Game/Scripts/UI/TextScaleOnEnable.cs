using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class TextScaleOnEnable : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private float maxScale = 1.7f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float positionMoveScale = 100f;
    [SerializeField] private float fadeScale = 1f;

    private Vector3 _originalPosition;

    private void Update()
    {
        var t = transform;
        var localScale = t.localScale;

        if (localScale.x >= maxScale)
        {
            gameObject.SetActive(false);
            return;
        }

        // Scale up
        t.localScale = localScale + Vector3.one * (speed * Time.deltaTime);

        // Reduce opacity
        var color = text.color;
        color.a -= speed * fadeScale * Time.deltaTime;
        text.color = color;

        // Move up
        // var rt = text.rectTransform;
        var position = t.position;
        position.y += positionMoveScale * speed * Time.deltaTime;
        t.position = position;
    }

    private void Reset()
    {
        var t = transform;

        // Reset color
        t.localScale = Vector3.one;

        // Reset scale
        var color = text.color;
        color.a = 1f;
        text.color = color;

        // Reset Position
        t.position = _originalPosition;
    }

    private void OnEnable()
    {
        _originalPosition = transform.position;
    }

    private void OnDisable()
    {
        Reset();
    }
}
