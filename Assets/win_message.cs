using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win_message : MonoBehaviour
{
    private board Boardscript;
    public GameObject main_object;
    Vector3 goal;

    // Start is called before the first frame update
    void Start()
    {
        goal = new Vector3(transform.localPosition.x, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        Boardscript = main_object.GetComponent<board>();
        if (Boardscript.score==64)
        {
            var position = transform.localPosition;
            transform.localPosition = Vector3.MoveTowards(position, goal, 200f * Time.deltaTime);
        }
    }
}
