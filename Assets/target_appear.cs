using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_appear : MonoBehaviour
{
    Vector3 goal;
    // Start is called before the first frame update
    void Start()
    {
        goal = new Vector3(transform.position.x, transform.position.y+0.3f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        transform.position = Vector3.MoveTowards(position, goal, 0.25f * Time.deltaTime);
    }
}
