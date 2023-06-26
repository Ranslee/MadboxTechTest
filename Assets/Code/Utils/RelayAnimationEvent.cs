using System;
using UnityEngine;
using UnityEngine.Events;

public class RelayAnimationEvent : MonoBehaviour
{
    [SerializeField] private AnimationEvent[] triggerEvents;

    public void FireAnimationEvent(string eventKey)
    {
        for (int i = 0; i < triggerEvents.Length; i++)
        {
            if (triggerEvents[i].EventKey == eventKey)
            {
                triggerEvents[i].Event.Invoke();
            }
        }
    }

    [Serializable]
    private struct AnimationEvent
    {
        public string EventKey;
        public UnityEvent Event;
    }
}