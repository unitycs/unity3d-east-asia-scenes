using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraControl : MonoBehaviour
{
    private float mX;
    private float mY;

    public float mouseSensitivity = 200f;

    //角度限制  
    private float MinLimitY = -85;
    private float MaxLimitY = 85;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mX += Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        mY -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

        if (mX == 0 && mY == 0) return;
        mY = ClampAngle(mY, MinLimitY, MaxLimitY);

        Quaternion mRotation = Quaternion.Euler(mY, mX, 0);
        transform.rotation = mRotation;
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
