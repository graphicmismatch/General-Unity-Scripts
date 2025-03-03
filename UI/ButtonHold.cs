using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class ButtonHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler 
{     
    public bool buttonPressed;
    public UnityEvent ButtonEvent = new UnityEvent(); 
    public void OnPointerDown(PointerEventData eventData){
        buttonPressed = true;
        ButtonEvent?.Invoke();
    }
     
    public void OnPointerUp(PointerEventData eventData){
        buttonPressed = false;
        ButtonEvent?.Invoke();
    }
}