using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerFist : XRInputFunction
{
    [SerializeField] private bool right;
    [SerializeField] private Rigidbody rbody;
    [SerializeField] private float power;

    [SerializeField] TrailRenderer trail;
    Vector3 lastPos;
    [SerializeField] float maxBoostTime;
    [SerializeField] static float rechargeSpeed;
    [SerializeField] static float boosterCharge;
    // Start is called before the first frame update
    void Start()
    {
        boosterCharge = maxBoostTime;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos = transform.position - rbody.position;
        if (buttonHeld(right,false))
        {
            if (boosterCharge > 0)
            {
                trail.enabled = true;
                boosterCharge -= Time.deltaTime;
                // booster rockets
                
                Vector3 thrustVector = ((relativePos - lastPos) * power) / Time.deltaTime;
                rbody.AddForce(thrustVector, ForceMode.Acceleration);
                Vibrate(0.5f, right);
            }  
        } else
        {
            trail.enabled = false;
            // recharge boosters
            boosterCharge += Time.deltaTime * rechargeSpeed;
        }
        lastPos = relativePos;
    }
}
