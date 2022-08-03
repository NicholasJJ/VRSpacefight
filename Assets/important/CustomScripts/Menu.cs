using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Gvr;
using UnityEngine.XR;

public class Menu : XRInputFunction
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject waveControl;
    [SerializeField] Camera menuCam;
    private bool startingGame;
    private GameObject startButton;

    public GameObject menuRig;
    // Start is called before the first frame update
    void Start()
    {
        startingGame = false;
        startButton = GameObject.Find("StartButton");
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("XRDEVICE:" + XRDevice.fovZoomFactor);
        if (startingGame) {
            transform.position = Vector3.Lerp(transform.position, startButton.transform.position, .2f);
            if (Vector3.Distance(transform.position, startButton.transform.position) <= .01f) {
                player.SetActive(true);
                player.GetComponent<nitro>().Begin(1);
                waveControl.SetActive(true);
                waveControl.GetComponent<EnemyWaveControl>().Begin();
                transform.parent.gameObject.SetActive(false);
                menuRig.SetActive(false);
                XRInputFunction.refreshControllers();
            }
        } else {
            if (anyButtonPressed())
            {
                if (!Physics.Raycast(transform.position, GameObject.Find("MenuCamera").transform.forward, 50f))
                {
                    //CardboardManager.RecenterCamera();
                }
                    
            }
        }
    }
    public bool isClicking(GameObject obj)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, GameObject.Find("MenuCamera").transform.forward, out hit)){
            if (hit.transform.gameObject.Equals(obj))
                return true;
        }
        return false;
    }
    public void OnShipAlign() {
        startingGame = true;
    }

}
