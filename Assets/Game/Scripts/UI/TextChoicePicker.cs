using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class TextChoicePicker : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private string[] options;

    private void Awake()
    {
        text.text = options[Random.Range(0, options.Length)];
    }
}
