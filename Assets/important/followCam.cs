using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCam : MonoBehaviour
{
    [SerializeField] Transform camera;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > camera.position.y) {
            transform.position = camera.position;
        } else
        {
            transform.position = new Vector3(camera.position.x, transform.position.y, camera.position.z);
        }
        Vector3 dir = camera.position - transform.position;
        dir = Vector3.ClampMagnitude(dir, speed * Time.deltaTime);
        transform.Translate(dir);
    }

    public float yDist()
    {
        return camera.position.y - transform.position.y;
    }

    public void resetPos()
    {
        transform.position = camera.position;
    }
}
