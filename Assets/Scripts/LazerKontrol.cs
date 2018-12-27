using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerKontrol : MonoBehaviour {

    private LineRenderer lr;
    private EdgeCollider2D ec;
    public GameObject lazer1;
    public GameObject lazer2;

    void Start () {
        lr = GetComponent<LineRenderer>();
        ec = GetComponent<EdgeCollider2D>();
        Vector2 sp = lazer1.transform.position;
        Vector2 ep = lazer2.transform.position;
        Vector2[] tempArray = { sp, ep };
        

        lr.SetVertexCount(2);
        lr.SetPosition(0, sp);
        lr.SetPosition(1, ep);

        ec.points = tempArray;
    }
	
	
	void Update () {

       

    }
}
