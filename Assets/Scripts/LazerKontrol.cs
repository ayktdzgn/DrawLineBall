using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerKontrol : MonoBehaviour {

    private LineRenderer lr;
    private EdgeCollider2D ec;
    public GameObject lazer1;
    public GameObject lazer2;
    Vector2[] lasersHandles;
    public float laserTime = 1f;
    public Material[] materials;

    public float yesilLazer = 2f;
    public float kirmiziLazer = 4f;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        ec = GetComponent<EdgeCollider2D>();
        Vector2[] lasersHandles = { lazer1.transform.position, lazer2.transform.position };
        ec.points = lasersHandles;
    }


    void Update()
    {
        if (lr.enabled == false)
        {
       
                StartCoroutine(StartLaser());
          
        }

    }

    IEnumerator StartLaser()
    {

        lr.enabled = true;
        lr.material = materials[0];
        lr.positionCount = 2;
        lr.SetPosition(0, lazer1.transform.position);
        lr.SetPosition(1, lazer2.transform.position);
        lr.startWidth = 0.02f;
        lr.endWidth = 0.02f;
        yield return new WaitForSeconds(yesilLazer);
        lr.material = materials[1];
        lr.positionCount = 2;
        lr.SetPosition(0, lazer1.transform.position);
        lr.SetPosition(1, lazer2.transform.position);
        lr.startWidth = 0.15f;
        lr.endWidth = 0.15f;
        ec.enabled = true;
        yield return new WaitForSeconds(kirmiziLazer);
        laserTime = 1f;
        lr.enabled = false;
        ec.enabled = false;

    }
}
