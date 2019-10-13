using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraBallCtrl : MonoBehaviour
{
    // public MenuCtrl menu;
    public Transform target;
    //是否看见鼠标
    public bool IsMouseActive = false;
    //鼠标灵敏度
    public float MouseSensitivity = 200f;
    //是否启用差值  
    public bool isNeedDamping = true;
    //过渡速度  
    public float Damping = 2.5F;

    private float mX, mY;
    //角度限制  
    private float MinLimitY = -90;
    private float MaxLimitY = 90;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = IsMouseActive;
    }
    
    public void SliderFunc_MouseSensitivity(Slider slider)
    {
        MouseSensitivity = slider.value * 300f;
    }

    // Update is called once per frame
    void Update()
    {
        // if (menu.isMenu) return;
        transform.position = target.position + 1.8f * target.up;
        mX += Input.GetAxis("Mouse X") * MouseSensitivity * 0.02f;
        mY -= Input.GetAxis("Mouse Y") * MouseSensitivity * 0.02f;
        //范围限制  
        mY = ClampAngle(mY, MinLimitY, MaxLimitY);

        //if (mY<=0)
        //{
        //    transform.Find("DemoCamera").position = Vector3.Lerp(transform.Find("DemoCamera").position,
        //        transform.position - transform.Find("DemoCamera").forward * (3.6f * (mY + 90f) * (mY + 90f) / 8100f + 1.4f), Time.deltaTime * 2f);
        //}
        //else if(Vector3.Distance(transform.position,transform.Find("DemoCamera").position) < 4.9f)
        //{
        //    print(1);
        //    transform.Find("DemoCamera").position = Vector3.Lerp(transform.Find("DemoCamera").position,
        //        transform.position - transform.Find("DemoCamera").forward * 5f, Time.deltaTime * 2f);
        //}

        Quaternion mRotation = Quaternion.Euler(mY, mX, 0);
        if(isNeedDamping)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, mRotation, Time.deltaTime * Damping);
        }
        else
        {
            transform.rotation = mRotation;
        }
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
