using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// I used this example for the raycasts: https://github.com/TUTOUNITYFR/tutoriel-navmesh-unity-tufr/blob/main/Assets/PlayerController.cs

public class PlayerScript : MonoBehaviour
{

    public Camera cam;
    public NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        GameObject objectHit = col.gameObject;
        //Debug.Log("Collision avec " + objectHit.name);

        if (objectHit.name == "Car")
        {
            GameObject.Find("Game").GetComponent<GameScript>().Win();
            gameObject.SetActive(false);
        }
    }
}
