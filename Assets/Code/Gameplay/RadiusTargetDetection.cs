using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RadiusTargetDetection<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private SphereCollider detectionTrigger;
    private List<T> targetsInRange = new List<T>();

    public bool HasTargetsInRange => targetsInRange.Count > 0;

    public void AddTarget(Collider other)
    {
        if (other.TryGetComponent(out T target) && targetsInRange.Contains(target) == false)
        {
            targetsInRange.Add(target);
        }
    }

    public void RemoveTarget(Collider other)
    {
        if (other.TryGetComponent(out T target) && targetsInRange.Contains(target))
        {
            targetsInRange.Remove(target);
        }
    }

    public T GetClosestTarget()
    {
        float shortestDistance = Mathf.Infinity;
        int closestTargetIndex = -1;
        for (int i = 0; i < targetsInRange.Count; i++)
        {
            float targetDistance = Vector3.Distance(transform.position, targetsInRange[0].transform.position);
            if (targetDistance < shortestDistance)
            {
                shortestDistance = targetDistance;
                closestTargetIndex = i;
            }
        }

        return targetsInRange[closestTargetIndex];
    }

    public void SetDetectionRange(float range)
    {
        detectionTrigger.radius = range;
    }
}