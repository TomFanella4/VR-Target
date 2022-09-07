using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using VRTargetShooter.Core.Singletons;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{
    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    //public delegate void EndTouchEvent(Vector2 position, float time);
    //public event EndTouchEvent OnEndTouch;

    private void OnEnable()
    {
        TouchSimulation.Enable();
        EnhancedTouchSupport.Enable();
        Touch.onFingerDown += FingerDown;
    }

    private void OnDisable()
    {
        TouchSimulation.Disable();
        EnhancedTouchSupport.Disable();
        Touch.onFingerDown -= FingerDown;
    }

    //private void StartTouch(InputAction.CallbackContext context)
    //{
    //    Debug.Log("Touch started " + touchControls.Touch.TouchPosition.ReadValue<Vector2>());
    //    if (OnStartTouch != null) OnStartTouch(touchControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
    //}

    //private void EndTouch(InputAction.CallbackContext context)
    //{
    //    Debug.Log("Touch ended " + touchControls.Touch.TouchPosition.ReadValue<Vector2>());
    //    if (OnEndTouch != null) OnEndTouch(touchControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.time);
    //}

    private void FingerDown(Finger finger)
    {
        OnStartTouch?.Invoke(finger.screenPosition, Time.time);
    }

    //private void Update()
    //{
    //    Debug.Log(UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches);
    //    foreach(UnityEngine.InputSystem.EnhancedTouch.Touch touch in UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches)
    //    {
    //        Debug.Log(touch.phase == UnityEngine.InputSystem.TouchPhase.Began);
    //    }
    //}
}
