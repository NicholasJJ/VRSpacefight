using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetector : MonoBehaviour
{
    public bool onGround;

    private void OnCollisionStay(Collision collision)
    {
        onGround = true;
    }
}
