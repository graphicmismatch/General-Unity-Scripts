using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
public class DraggableManager : MonoBehaviour
{

    public static DraggableManager instance;
    public float dragTime;
    public bool worldSpaceMatters;
    public bool TouchMode;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            TouchMode = true;
            EnhancedTouchSupport.Enable();
        }
        else { 
            TouchMode= false;
            EnhancedTouchSupport.Disable();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
