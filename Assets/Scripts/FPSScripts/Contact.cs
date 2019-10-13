using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "WoodenBox")
            Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
