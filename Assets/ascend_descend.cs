using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ascend_descend : MonoBehaviour
{
    Vector3 goal;
    int faze = 0;
    float distance;
    private board Boardscript;
    public GameObject main_object;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        goal = new Vector3(transform.position.x, transform.position.y - 53, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        distance = Vector3.Distance(position, goal);
        if (faze<2)
        {
            if (faze == 0)
            {
                if (distance < 4)
                {
                    transform.position = Vector3.MoveTowards(position, goal, (1 + 6*distance) * Time.deltaTime);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(position, goal, 25f * Time.deltaTime);
                }
                if (distance < 0.1)
                {
                    faze = 1;
                    goal = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z);
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(position, goal, (25-6*distance) * Time.deltaTime);
            }
        }
        else
        {
            timer = timer + Time.deltaTime;
            if (timer > 3)
                    {
                position = transform.position;
                distance = Vector3.Distance(position, goal);
                transform.position = Vector3.MoveTowards(position, goal, 25f * Time.deltaTime);
                if (distance < 0.1)
                {
                    // SceneManager.LoadScene(0);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
        Boardscript = main_object.GetComponent<board>();
        if(Boardscript.done==true)
        {
            if (Boardscript.markers == 0)
            {
                if (Boardscript.score != 64)
                {
                    if (faze == 1)
                    { 
                    faze = 2;
                    goal = new Vector3(transform.position.x, transform.position.y + 53, transform.position.z);
                     }
                }
            }
        }
        


    }
}