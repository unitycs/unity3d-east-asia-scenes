using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player") return;
        if(Input.GetButtonDown("拾取"))
        {
            GameObject pfb_m16 = (GameObject)Resources.Load("Prefabs/M16");
            GameObject mCamera = GameObject.Find("FPSPlayer/FPSCamera");
            pfb_m16 = Instantiate(pfb_m16);
            pfb_m16.transform.parent = mCamera.transform;
            pfb_m16.transform.rotation = mCamera.transform.rotation;
            pfb_m16.transform.localPosition = new Vector3(0.73f, -0.508f, 0.931f);

            Destroy(gameObject);
        }
    }
}
