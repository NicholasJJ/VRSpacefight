using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleSword : XRInputFunction
{
    bool a;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerPressed(false))
        {
            a = !a;
            GetComponent<Collider>().enabled = a;
            GetComponent<MeshRenderer>().enabled = a;
        }
    }
}
