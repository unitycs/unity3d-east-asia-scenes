using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RobotCtrl : MonoBehaviour
{
    public Transform FollowedCamera;
    protected Animator m_Anim;
    CharacterController m_Ctrl;
    public float m_Speed=0.1f;

    public GameObject kaifuku;

    public int HeartMax;
    public int HeartNow;
    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
        m_Ctrl = GetComponent<CharacterController>();
        HeartMax = 4;
        HeartNow = 3;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("横向移动");
        float v = Input.GetAxis("纵向移动");
        Vector3 mDir;
        if (h!=0 || v!=0)
        {
            mDir = new Vector3(v * FollowedCamera.transform.forward.x + h * FollowedCamera.transform.right.x,
                0, v * FollowedCamera.transform.forward.z + h * FollowedCamera.transform.right.z);
            Quaternion newRotation = Quaternion.LookRotation(mDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.9f);

            m_Ctrl.Move(mDir*Time.deltaTime);
;
            if (!m_Anim.GetBool("Run")) m_Anim.SetBool("Run", true);
        }
        else
        {
            if (m_Anim.GetBool("Run")) m_Anim.SetBool("Run", false);
        }

        //if(Input.GetKey(KeyCode.Z))
        //{
        //    transform.GetChild(2).gameObject.SetActive(true);
        //}
        //else
        //{
        //    transform.GetChild(2).gameObject.SetActive(false);
        //}

        if(Input.GetKey(KeyCode.H))
        {
            if (HeartNow == HeartMax) return;
            if ( ! kaifuku.activeSelf)
                kaifuku.SetActive(true);
        }
        else
        {
            if (kaifuku.activeSelf)
            {
                kaifuku.GetComponent<CircleProgress>().ResetCurrent();
                kaifuku.SetActive(false);
            }
        }
    }
}
