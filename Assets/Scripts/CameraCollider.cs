using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraCollider : MonoBehaviour {
    public Transform target;
    public float distance=5f;
	// Use this for initialization
	void Start () {
		
	}	

	// Update is called once per frame
	void Update () {
        Vector3 dir = transform.position - target.position;
        Ray ray = new Ray(target.position, dir);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, LayerMask.GetMask("Terrian")))
        {
            //transform.SetPositionAndRotation(hitInfo.point, transform.rotation);
            transform.position = Vector3.Lerp(transform.position,hitInfo.point,Time.deltaTime * 20f);
        }
        else
        {
            transform.position = target.position + dir;
            //if (dir.sqrMagnitude<(distance*distance))
            //{
            //    transform.position = target.position - transform.forward * distance;
            //   //transform.SetPositionAndRotation(target.position - transform.forward * 5f, transform.rotation);
            //}
        }
    }
}
