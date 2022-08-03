using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollMover : MonoBehaviour
{
    public GameObject hull;
    [SerializeField] float forwardAngle;
    [SerializeField] followCam jumpTest;
    [SerializeField] collisionDetector colDet;
    [SerializeField] float jumpTrigger;
    [SerializeField] float jumpForce;
    [SerializeField] private float turnSpeed;
    // Start is called before the frst irame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 comp = Vector3.Cross(transform.forward, transform.right);
        Vector3 comp = Vector3.RotateTowards(transform.up, transform.forward, forwardAngle * Mathf.Deg2Rad, 0);
        Quaternion r = Quaternion.FromToRotation(Vector3.up, comp);
        hull.GetComponent<Rigidbody>().angularVelocity = new Vector3(turnSpeed * UsableDegree(r.eulerAngles.x) / 90, 0, turnSpeed * UsableDegree(r.eulerAngles.z) / 90);

        //jump
        if (jumpTest.yDist() >= jumpTrigger && colDet.onGround)
        {
            Debug.Log("jump");
            jumpTest.resetPos();
            hull.GetComponent<Rigidbody>().velocity += Vector3.up * jumpForce;
            colDet.onGround = false;
        }
    }

    float UsableDegree(float inp)
    {
        if (inp > 180) return -360 + inp;
        return inp;
    }
}
