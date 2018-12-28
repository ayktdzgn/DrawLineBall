using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCol;

    
    public float Period = 0.7f;
    private float removeTime=2f;

    bool pointVar = true;



    List<Vector2> points;
    

    public void UpdateLine(Vector2 mousePos)
    {
        if (points == null)
        {
            points = new List<Vector2>();
            SetPoint(mousePos);
            return;
        }

        if (Vector2.Distance(points.Last(), mousePos) > .1f)
            SetPoint(mousePos);
    }


    void SetPoint(Vector2 point)
    {
        points.Add(point);

        lineRenderer.numPositions = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);

        if (points.Count > 1)
            edgeCol.points = points.ToArray();
    }



    public void Update()
    {
        if (pointVar == true)
        {
            if (removeTime < 0)
            {
                StartCoroutine(RemovePoints());
                
            }
            removeTime -= Time.deltaTime ;
        }
        
    }

    IEnumerator RemovePoints()
    {

        yield return new WaitForSeconds(Period);

        points.RemoveAt(0);

        for (int i = 0; i < points.Count; i++)
        {
            lineRenderer.SetPosition(i, points[i]);

        }
        lineRenderer.numPositions = points.Count;


        if (points.Count  >= 0)
        {
            edgeCol.points = points.ToArray();
        }

        if(points.Count == 0)
        {
            Destroy(gameObject, 0f);
        }

        if(points.Count <= 0)
        {
            pointVar = false;
        }
    
    
    }

}
