using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameScript : MonoBehaviour
{
    private bool win = false;
    private int i = 0;
    //private bool lose = false;
    GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        GameObject car = GameObject.Find("Car");
    }

    // Update is called once per frame
    void Update()
    {
        if (win)
        {
            Vector3 carPos = GameObject.Find("Car").GetComponent<Rigidbody>().transform.position;
            Quaternion carRot = GameObject.Find("Car").GetComponent<Rigidbody>().transform.rotation;
            GameObject.Find("Car").GetComponent<Rigidbody>().transform.SetPositionAndRotation(new Vector3(carPos.x-0.2f, carPos.y, carPos.z), carRot);
            var move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (i > 200)
                LevelFinished();
            else
                i++;
        }
    }

    public void LevelFinished()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name.Equals("level_0"))
        {
            SceneManager.LoadScene("level_1");
            SceneManager.UnloadSceneAsync("level_0");
        }
    }

    public void Win()
    {
        GameObject textObject = GameObject.Find("Text");
        if (textObject == null)
            Debug.Log("Text object not found");
        win = true;

        if (SceneManager.GetActiveScene().name.Equals("level_0")) {
            textObject.GetComponent<TextMeshPro>().text = "Level Finished";
        }
        else
        {
            textObject.GetComponent<TextMeshPro>().text = "You win";
        }
    }

    public void Lose()
    {
        GameObject textObject = GameObject.Find("Text");
        if (textObject == null)
            Debug.Log("Text object not found");
        textObject.GetComponent<TextMeshPro>().text = "You lose";
    }
}
