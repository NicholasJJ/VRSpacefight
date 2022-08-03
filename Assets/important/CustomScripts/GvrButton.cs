 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GvrButton : XRInputFunction
{
    private bool startingGame;
    [SerializeField] GameObject menuCamera;
    // Start is called before the first frame update
    void Start()
    {
        startingGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (anyButtonPressed()) {
            if (menuCamera.GetComponent<Menu>().isClicking(gameObject))
            {
                startingGame = true;
                GetComponent<AutoRotate>().enabled = false;
            }
        }
        if (startingGame) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, .2f);
            if (Quaternion.Angle(transform.rotation, Quaternion.identity) < 1)
                GameObject.Find("Menu").GetComponent<Menu>().OnShipAlign();
        }
    }
}
