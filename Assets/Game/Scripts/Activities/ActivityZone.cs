using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ActivityZone : MonoBehaviour
{
    [SerializeField] private SphereCollider sphereCollider;
    [SerializeField] private Activity activity;

    private EActivityZoneEntered _enteredEvent;
    private EActivityZoneExited _exitedEvent;

    private void Awake()
    {
        if (activity == null) activity = GetComponent<Activity>();
        if (sphereCollider == null) sphereCollider = GetComponent<SphereCollider>();

        // Ensure collider is trigger
        sphereCollider.isTrigger = true;

        // Initialize events
        _enteredEvent = new EActivityZoneEntered()
        {
            Activity = activity,
        };
        _exitedEvent = new EActivityZoneExited()
        {
            Activity = activity,
        };
    }

    private void OnTriggerEnter(Collider other)
    {
        _enteredEvent.Emit();
    }

    private void OnTriggerExit(Collider other)
    {
        _exitedEvent.Emit();
    }
}
