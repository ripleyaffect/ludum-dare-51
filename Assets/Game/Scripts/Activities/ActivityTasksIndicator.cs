using TMPro;
using UnityEngine;

public class ActivityTasksIndicator : MonoBehaviour
{
    [SerializeField] private TMP_Text taskCountText;

    public void SetTaskPoints(int taskPoints)
    {
        taskCountText.text = taskPoints.ToString();
    }
}
