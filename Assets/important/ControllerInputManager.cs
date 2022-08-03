using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class ControllerInputManager : MonoBehaviour
{
    public bool left;
    private XRController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<XRController>();
    }

    // Update is called once per frame
    void Update()
    {
        //controller.activateInteractionState.activatedThisFrame
    }
}
