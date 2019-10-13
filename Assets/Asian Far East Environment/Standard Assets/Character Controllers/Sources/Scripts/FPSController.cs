using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    protected CharacterController m_Ctrl;
    public float m_Speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        m_Ctrl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (h != 0 || v != 0)
        {
            Vector3 mDir = v * transform.forward + h*transform.right;
            m_Ctrl.SimpleMove(mDir * m_Speed);
        }
        else
        {           
        }

    }
}
