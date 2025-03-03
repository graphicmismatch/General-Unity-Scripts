using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.InputSystem.EnhancedTouch;

public class Draggable : MonoBehaviour
{
    public bool clicked = false;
    bool dragging = false;
    public float clicktime = 0.2f;
    private float clickdur = 0f;
    public RectTransform rt;
    public ButtonHold but;
    private Vector3 offset;
    public UnityEvent OnClick;
    public UnityEvent DragBegin;
    public UnityEvent DragEnd;
    // Start is called before the first frame update
    void Start()
    {
        clicktime = DraggableManager.instance.dragTime;
    }

    // Update is called once per frame
    void Update()
    {
        var t = new UnityEngine.InputSystem.EnhancedTouch.Touch();
        if (DraggableManager.instance.TouchMode)
        {
            t = UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches[0];
        }
        if (!clicked)
        {
            clicked = but.buttonPressed;
            if (clicked)
            {
                if (DraggableManager.instance.worldSpaceMatters)
                {
                    offset = rt.position - Camera.main.ScreenToWorldPoint((DraggableManager.instance.TouchMode) ? (Vector3)Mouse.current.position.value : (Vector3)t.screenPosition);
                }
                else
                {
                    offset = rt.position - ((DraggableManager.instance.TouchMode) ? (Vector3)Mouse.current.position.value : (Vector3)t.screenPosition);
                }
            }
        }
        if (clicked)
        {
            if (!Mouse.current.press.isPressed)
            {
                if (clickdur < clicktime)
                {
                    OnClick?.Invoke();
                }
                else
                {
                    DragEnd?.Invoke();
                }
                clicked = false;
                clickdur = 0;
                dragging = false;
            }

            if (clickdur >= clicktime)
            {
                if (!dragging)
                {
                    dragging = true;
                    DragBegin?.Invoke();
                }
                if (DraggableManager.instance.worldSpaceMatters)
                {
                    rt.position = Camera.main.ScreenToWorldPoint(((DraggableManager.instance.TouchMode) ? (Vector3)Mouse.current.position.value : (Vector3)t.screenPosition) + offset);
                }
                else
                {
                    rt.position = ((DraggableManager.instance.TouchMode) ? (Vector3)Mouse.current.position.value : (Vector3)t.screenPosition) + offset;
                }
            }

            clickdur += Time.deltaTime;


        }

    }


}
