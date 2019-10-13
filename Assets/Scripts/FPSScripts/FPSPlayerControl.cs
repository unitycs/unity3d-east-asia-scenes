using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayerControl : MonoBehaviour
{
    protected CharacterController m_characterController;
    public float MoveSpeed = 100f;

    public float JumpForce = 100f;
    private bool isJumping;

    private Vector3 mDir;
    // Start is called before the first frame update
    void Start()
    {
        m_characterController = GetComponent<CharacterController>();
        isJumping = false;
        mDir = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isJumping)
        {
            float h = Input.GetAxis("横向移动");
            float v = Input.GetAxis("纵向移动");
            if (h != 0 || v != 0)
            {
                mDir = new Vector3(v * Camera.main.transform.forward.x + h * Camera.main.transform.right.x,
                       0, v * Camera.main.transform.forward.z + h * Camera.main.transform.right.z) * MoveSpeed;
                //GetComponent<ConstantForce>().force = mDir;
                //GetComponent<Rigidbody>().velocity = mDir;
            }

            if (Input.GetButtonDown("跳跃"))
            {
                mDir.y = JumpForce;
                isJumping = true;
            }
            //应用重力。
            //mDir.y -= gravity * Time.deltaTime;
        }
        else
        {
            if (m_characterController.isGrounded)
            {
                mDir = Vector3.zero;
                isJumping = false;
            }
        }

        m_characterController.Move(mDir * Time.deltaTime);
    }
}
