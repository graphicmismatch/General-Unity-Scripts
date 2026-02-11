using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HeldButton : Button
{
    public bool isHeld { get; private set; }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        isHeld = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        isHeld = false;
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        isHeld = false;
    }
}