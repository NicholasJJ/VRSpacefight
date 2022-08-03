using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRInputFunction : MonoBehaviour
{
    private static XRController leftController;
    private static XRController rightController;

    private void Awake()
    {
        refreshControllers();
    }

    public static void refreshControllers()
    {
        leftController = GameObject.FindGameObjectWithTag("lController").GetComponent<XRController>();
        rightController = GameObject.FindGameObjectWithTag("rController").GetComponent<XRController>();
    }

    public bool anyButtonPressed()
    {
        if (ControllersNotConnected()) return false;
        return leftController.activateInteractionState.activatedThisFrame || rightController.activateInteractionState.activatedThisFrame;
    }

    public bool anyButtonHeld()
    {
        if (ControllersNotConnected()) return false;
        return leftController.activateInteractionState.active || rightController.activateInteractionState.active;
    }

    public bool triggerPressed(bool right)
    {
        if (ControllersNotConnected()) return false;
        if (right) return rightController.activateInteractionState.activatedThisFrame;
        return leftController.activateInteractionState.activatedThisFrame;
    }

    public bool buttonHeld(bool right, bool trigger)
    {
        XRController controller = right ? rightController : leftController;
        return trigger ? controllerTriggerHeld(controller) : controllerGripHeld(controller);
    }

    private bool controllerGripHeld(XRController controller)
    {
        return controller.selectInteractionState.active;
    }

    private bool controllerTriggerHeld(XRController controller)
    {
        return controller.activateInteractionState.active;
    }

    public void Vibrate(float intensity, bool right)
    {
        if (right)
        {
            rightController.SendHapticImpulse(intensity, 0.5f);
        }
        else
        {
            leftController.SendHapticImpulse(intensity, 0.5f);
        }
        
    }

    private bool ControllersNotConnected()
    {
        return !(leftController != null && rightController != null);
    }
}
