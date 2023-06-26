using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private Joystick joystick;

    public static Vector2 MoveAxis;

    private bool dragging;
    private int dragPointerID;
    private Vector2 inputOrigin;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (dragging)
            return;

        dragging = true;
        dragPointerID = eventData.pointerId;
        inputOrigin = eventData.position;
        joystick.MoveAnchor(inputOrigin);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragging == false || eventData.pointerId != dragPointerID)
            return;

        var direction = eventData.position - inputOrigin;
        joystick.MoveInner(direction);
        MoveAxis = joystick.NormalizedInnerOffset;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (dragging == false || eventData.pointerId != dragPointerID)
            return;

        dragging = false;
        dragPointerID = -1;
        inputOrigin = Vector2.zero;
        joystick.ResetPositions();
        MoveAxis = Vector2.zero;
    }
}
