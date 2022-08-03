using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handGun : XRInputFunction
{
    [SerializeField] private bool right;
    public GameObject bullet;
    public Transform shootPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerPressed(right))
        {
            GameObject newBullet = Instantiate(bullet, shootPosition.position, shootPosition.rotation);
            newBullet.GetComponent<autoMove>().isPlayerBullet = true;
            newBullet.transform.localScale.Scale(new Vector3(0.1f,0.1f,0.1f));
        }
    }
}
