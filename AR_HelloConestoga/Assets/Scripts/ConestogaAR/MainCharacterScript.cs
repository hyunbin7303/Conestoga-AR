using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterScript : MonoBehaviour
{
    private List<Transform> nodes = new List<Transform>();
    public bool isMoving;
    public Transform NextTargetWayPoint;
    private float speed = 0.1f;
    public int curPoint = 0;
    void Start()
    {
        isMoving = false;
        curPoint = 0;
    }
    
    void Update()
    {
        if(isMoving)
        {
            PlayerMoving();
        }
    }
    public void PlayerMoving()
    {
        transform.position = Vector3.MoveTowards(transform.position, NextTargetWayPoint.position, speed * Time.deltaTime);
        float step = speed * Time.deltaTime;
        Vector3 targetDir = NextTargetWayPoint.position - transform.position;

        // Position is the same.
        if(transform.position == NextTargetWayPoint.position){
            isMoving = false;
        }
    }
    public void setUpTargetPoint(Transform TransformLoc){
        NextTargetWayPoint = TransformLoc;
    }
}
