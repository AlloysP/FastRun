using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class FollowerScript : MonoBehaviour
{

    public GameObject leader;
    public NavMeshAgent agent;

    private float minSpeed;
    private float maxSpeed;


    // Start is called before the first frame update
    void Start()
    {
        float ininitalSpeed = this.GetComponent<NavMeshAgent>().speed;
        minSpeed = ininitalSpeed / 1.5f;
        maxSpeed = ininitalSpeed * 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(leader.GetComponent<NavMeshAgent>().destination);

        float myDistToDest = Vector3.Distance(this.transform.position, agent.destination);

        //Debug.Log("myDistToDest=" + myDistToDest);
        if (myDistToDest<5)
        {
            agent.speed -= 0.03f;
        }
        else {
            if (agent.speed < minSpeed)
                agent.speed = minSpeed;
            float leaderDistToDest = Vector3.Distance(leader.transform.position, leader.GetComponent<NavMeshAgent>().destination);
            Vector3 myPos = this.transform.position;
            if (myDistToDest - leaderDistToDest < 1)
            {
                //Debug.Log("0");
                if (agent.speed > minSpeed)
                    agent.speed -= 0.002f;
            }
            else
            {
                //Debug.Log("1");
                if (agent.speed < maxSpeed)
                    agent.speed += 0.002f;
            }
        }
        //Debug.Log("navMeshSpeed= " + agent.speed);
    }
}
