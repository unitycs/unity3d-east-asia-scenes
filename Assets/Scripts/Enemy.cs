using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform IkiSaki;
    private NavMeshAgent agent;

    private Animator m_anim;
    private Rigidbody m_body;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = IkiSaki.position;

        m_anim = GetComponent<Animator>();
        m_body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_body.velocity != Vector3.zero)
            m_anim.SetBool("Run", true);
        else m_anim.SetBool("Run", false);
    }
}
