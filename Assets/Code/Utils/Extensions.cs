using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static bool TryGetComponent<T> (this MonoBehaviour mb, out T component) where T : MonoBehaviour
    {
        component = mb.GetComponent<T>();
        return component != null;
    }

    public static bool Contains(this LayerMask layerMask, int gameObjectLayerMask)
    {
        return (layerMask.value & 1 << gameObjectLayerMask) > 0;
    }

    public static Vector3 ToVector3XZ(this Vector2 vector)
    {
        return new Vector3()
        {
            x = vector.x,
            y = 0,
            z = vector.y
        };
    }

    public static Vector3 RandomPointInBox(this BoxCollider boxCollider)
    {
        Vector3 extents = boxCollider.size / 2f;
        Vector3 point = new Vector3(
            Random.Range(-extents.x, extents.x),
            Random.Range(-extents.y, extents.y),
            Random.Range(-extents.z, extents.z)
        );

        return boxCollider.transform.TransformPoint(point);
    }
}
