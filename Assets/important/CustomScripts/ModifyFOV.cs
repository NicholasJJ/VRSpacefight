using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ModifyFOV : XRInputFunction
{
    [SerializeField] private float fovChange;
    private Camera cam;
    private Menu menu;
    private void Start()
    {
        cam = GameObject.Find("MenuCamera").GetComponent<Camera>();
        menu = GameObject.Find("Menu").GetComponent<Menu>();
    }
    private void Update()
    {
        if (anyButtonPressed())
        {
            if (menu.isClicking(gameObject))
                gotClicked();
        }
    }
    public void gotClicked() {
        Debug.Log("clicked!");
        float fov, aspect, zNear, zFar;

        Matrix4x4 mat;
        mat = cam.projectionMatrix;
        //Left eye
        GetProjectionMatrixParameters(mat, out fov, out aspect, out zNear, out zFar);

        mat = Matrix4x4.Perspective(fov + fovChange, aspect, zNear, zFar);

        cam.projectionMatrix = mat;

        Debug.Log("changing device FOV");
        XRDevice.fovZoomFactor = XRDevice.fovZoomFactor + fovChange;
    }

    //Function written by Bonfanti96
    public static void GetProjectionMatrixParameters(Matrix4x4 mat, out float fov, out float aspect, out float zNear, out float zFar)
    {
        float a = mat[0];
        float b = mat[5];
        float c = mat[10];
        float d = mat[14];

        aspect = b / a;

        float k = (c - 1.0f) / (c + 1.0f);
        zNear = (d * (1.0f - k)) / (2.0f * k);
        zFar = k * zNear;

        fov = Mathf.Rad2Deg * (2.0f * (float)Mathf.Atan(1.0f / b));
    }
}
