using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wander : MonoBehaviour
{
    [SerializeField] private float rotAmount;
    [SerializeField] private float speed;
    [SerializeField] private float maxRotAmount;
    [SerializeField] private float rotChangeRate;
    private Rigidbody rBody;
    // Start is called before the first frame update
    void Start()
    {
        rotAmount = 0;
        rBody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rotAmount += Random.Range(-rotChangeRate, rotChangeRate) * Time.deltaTime;
        rotAmount = Mathf.Clamp(rotAmount, -maxRotAmount, maxRotAmount);
        rBody.angularVelocity = new Vector3(0, rotAmount, 0);
        rBody.velocity = (transform.forward * speed) + (Vector3.up * rBody.velocity.y);
    }
}
