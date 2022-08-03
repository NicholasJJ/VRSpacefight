using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wobble : MonoBehaviour
{
    [SerializeField] private Vector3 axis;
    [SerializeField] private float maxAngle;
    [SerializeField] private float speed;
    [SerializeField] private bool flipped;

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Sin(Time.time * speed) * maxAngle;
        if (flipped) angle *= -1;
        transform.rotation = Quaternion.AngleAxis(angle, axis);
    }
}
