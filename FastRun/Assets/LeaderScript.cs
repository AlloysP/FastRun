using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

// I used and adapted some of this code: https://forum.unity.com/threads/solved-random-wander-ai-using-navmesh.327950/

public class LeaderScript : MonoBehaviour
{
    private float wanderRadius = 25;
    //public float wanderTimer = 1f;

    private Transform target;
    public NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        //Debug.Log("0");
        goToRandomDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Round((decimal)transform.position.x, 0) == Math.Round((decimal)agent.destination.x, 0) && Math.Round((decimal)transform.position.z, 0) == Math.Round((decimal)agent.destination.z, 0))
        {
            goToRandomDestination();
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = UnityEngine.Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    private void goToRandomDestination() {
        for (int i = 0; i < 200; i++)
        {
            //Debug.Log("i=" + i);
            agent.destination = RandomNavSphere(transform.position, wanderRadius, -1);
            if (agent.destination == null)
                Debug.Log("destination == null");
            //Debug.Log("destination.x = " + destination.x);
            if (agent.destination.x < 100000 && agent.destination.x > -100000) {
                agent.SetDestination(agent.destination);
                break;
            }
        }
    }
}
