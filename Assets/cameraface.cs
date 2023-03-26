using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraface : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(target);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(0, 0, 30.5f);
            transform.Rotate(0, 1.5f, 0, Space.World);
            transform.Translate(0, 0, -30.5f);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0, 0, 30.5f);
            transform.Rotate(0, -1.5f, 0, Space.World);
            transform.Translate(0, 0, -30.5f);
        }
       
        }

    
}
