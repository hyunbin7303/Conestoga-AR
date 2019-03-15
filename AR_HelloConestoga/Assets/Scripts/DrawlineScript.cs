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

    private bool isLineOn;


    private float lineDrawSpeed = 3f;
    private Color color = Color.red;
    private Color c1 = Color.white;
    // Start is called before the first frame update
    void Start()
    {
        isLineOn = false;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, origin.position);
        dist = Vector3.Distance(origin.position, destination.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(isLineOn)
        {
            Vector3 pointA = origin.position;
            Vector3 pointB = destination.position;
            lineRenderer.SetPosition(0, pointA);
            lineRenderer.SetPosition(1, pointB);
        }
        else
        {
           
        }


    }
    public void lineRenderOn()
    {
        isLineOn = true;
        lineRenderer.enabled = true;
    }
    public void lineRenderOff()
    {
        isLineOn = false;
        lineRenderer.enabled = false;
    }
    public bool getLineRender()
    {
        return isLineOn;
    }
}
