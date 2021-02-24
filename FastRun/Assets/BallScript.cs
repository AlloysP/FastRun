using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;


public class BallScript : MonoBehaviour
{
    public GameObject target;
    private Vector3 PositionDepart;
    private Quaternion RotationDepart;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        PositionDepart = transform.position;
        RotationDepart = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);
    }

    void OnCollisionEnter(Collision col)
    {
        GameObject objectHit = col.gameObject;
        //Debug.Log("Collision avec " + objectHit.name);

        if(objectHit == target)
        {
            Debug.Log("2");
            GameObject.Find("Game").GetComponent<GameScript>().Lose();
            objectHit.SetActive(false);
        }
    }

}