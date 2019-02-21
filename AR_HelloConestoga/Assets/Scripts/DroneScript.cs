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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
