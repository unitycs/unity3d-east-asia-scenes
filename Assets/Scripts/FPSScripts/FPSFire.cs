using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSFire : MonoBehaviour
{
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("射击"))
        {
            GameObject cf = Instantiate<GameObject>(bullet);
            cf.transform.position = Camera.main.transform.position;
            cf.transform.rotation = Camera.main.transform.rotation;
            cf.transform.position += cf.transform.forward;
            cf.GetComponent<Rigidbody>().velocity = cf.transform.forward * Time.deltaTime * 1000f;
        }
    }
}
