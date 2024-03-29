﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : XRInputFunction
{

    public GameObject bullet;
    public GameObject shoot1;
    public GameObject shoot2;
    public GameObject shootBack;
    public GameObject force;
    public GameObject Camera;
    public bool online = true;
    private bool shootLeft;
    private bool facingBack;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (anyButtonPressed() && !gameObject.GetComponent<fly2>().dead && !gameObject.GetComponent<nitro>().boosting)
        {
            Bangbang();
        }
    }
    void Bangbang()
    {
        Debug.Log("shooting");
        shootLeft = !shootLeft;
        facingBack = (force.transform.localPosition.z <= -0.5);
        if (facingBack) {
            CreateBullet(shootBack.transform.position);
        }
        else if (shootLeft) {
            CreateBullet(shoot1.transform.position);
        }
        else {
            CreateBullet(shoot2.transform.position);
        }
    }
    void CreateBullet(Vector3 pos) {
        GameObject nullet = Instantiate(bullet, pos, Camera.transform.rotation);
        nullet.GetComponent<autoMove>().isPlayerBullet = true;
    }
}

