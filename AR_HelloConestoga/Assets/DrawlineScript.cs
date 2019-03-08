using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawlineScript : MonoBehaviour
{

    private LineRenderer lineRenderer;
    private float counter;
    private float dist;

    public Transform origin;
    public Transform destination;

    private float lineDrawSpeed = 3f;
    private Color color = Color.red;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, origin.position);
        //lineRenderer.SetWidth(0.45f, 0.45f);
        dist = Vector3.Distance(origin.position, destination.position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pointA = origin.position;
        Vector3 pointB = destination.position;

        lineRenderer.SetPosition(0, pointA);
        lineRenderer.SetPosition(1, pointB);
        //if(counter < dist)
        //{
        //    counter += .1f / lineDrawSpeed;
        //    float x = Mathf.Lerp(0, dist, counter);
        //    Vector3 pointA = origin.position;
        //    Vector3 pointB = destination.position;

        //    //Get the unit vector in the desired Direction      
        //    Vector3 pointAlongLine = x * Vector3.Normalize(pointB - pointA) + pointA;

        //    lineRenderer.SetPosition(1, pointAlongLine); 
        //}
    }
}
