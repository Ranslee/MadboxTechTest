using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Trigger : MonoBehaviour
{
    [SerializeField] private TriggerEvent[] triggerEvents;

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < triggerEvents.Length; i++)
        {
            if (triggerEvents[i].collisionMask.Contains(other.gameObject.layer))
            {
                triggerEvents[i].EntryEvent.Invoke(other);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < triggerEvents.Length; i++)
        {
            if (triggerEvents[i].collisionMask.Contains(other.gameObject.layer))
            {
                triggerEvents[i].ExitEvent.Invoke(other);
            }
        }
    }

    [Serializable]
    private struct TriggerEvent
    {
        public LayerMask collisionMask;
        public UnityEvent<Collider> EntryEvent;
        public UnityEvent<Collider> ExitEvent;
    }
}