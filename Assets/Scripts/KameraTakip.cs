using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour {

    public Transform target;

    public float smoothSpeed = 1f;
    public Vector3 offset;

    private void LateUpdate()
    {
       
        if(target != null)
        {
            Vector3 desirePosition = new Vector3(transform.position.x, target.position.y + offset.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desirePosition, smoothSpeed);
            transform.position = new Vector3(transform.position.x, smoothedPosition.y, transform.position.z);
        }
        else
        {
            return;
        }

    }
}
