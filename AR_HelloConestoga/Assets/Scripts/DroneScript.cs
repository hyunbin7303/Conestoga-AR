using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneScript : MonoBehaviour
{

    public GameObject markerGoal;
    Vector3 parentPos;
    NavMeshAgent agent;

    void OnStart()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void MoveToTarget()
    {
        if(markerGoal.active)
        {
            parentPos = markerGoal.transform.parent.position;
            agent.SetDestination(parentPos);
        }
    }

    void Start()
    {
    }
    void Update()
    {
    }
}
