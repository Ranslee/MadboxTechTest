using UnityEngine;

public class Joystick : MonoBehaviour
{
    [SerializeField] private RectTransform anchor;
    [SerializeField] private RectTransform inner;

    [SerializeField] private Vector3 defaultAnchorPosition;
    [SerializeField] private float maxInnerOffset;

    public Vector2 NormalizedInnerOffset => Vector2.ClampMagnitude(inner.localPosition / maxInnerOffset, 1f);
    

    public void MoveAnchor(Vector2 position)
    {
        anchor.position = position;
    }

    public void MoveInner(Vector2 offset)
    {
        inner.localPosition = Vector2.ClampMagnitude(offset, maxInnerOffset); ;   
    }

    public void ResetPositions()
    {
        anchor.anchoredPosition = defaultAnchorPosition;
        inner.localPosition = Vector2.zero;
    }
}
