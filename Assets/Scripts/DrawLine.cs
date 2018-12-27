using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {
    public Rigidbody2D noktaPrefab;

   

    private void OnMouseDrag()
    {
        Vector3 mouse = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(mouse);
        Rigidbody2D nokta;
        
        nokta = Instantiate(noktaPrefab, mouse,Quaternion.identity) as Rigidbody2D;
        

    }

   
 
}
